namespace Lesula.Cassandra
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using Lesula.Cassandra.Client;
    using Lesula.Cassandra.Cluster;
    using Lesula.Cassandra.Configuration;
    using Lesula.Cassandra.Exceptions;

    public sealed class AquilesHelper
    {
        private const string SECTION_CONFIGURATION_NAME = "CassandraConfiguration";

        #region static
        private static AquilesHelper _instance;
        static AquilesHelper()
        {
            AquilesClusterBuilder builder = new AquilesClusterBuilder();
            _instance = new AquilesHelper(builder, SECTION_CONFIGURATION_NAME);
        }

        /// <summary>
        /// Reinicializa o cluster do Cassandra
        /// </summary>
        public static void Reset()
        {
            var builder = new AquilesClusterBuilder();
            _instance = new AquilesHelper(builder, SECTION_CONFIGURATION_NAME);
        }


        /// <summary>
        /// Retrieve a connection for cluster associated with the given clusterName. In case there is no cluster configured with the friendly name given, an AquilesException is thrown.
        /// <remarks>can throw <see cref="AquilesException"/> in case something went wrong</remarks>
        /// </summary>
        /// <param name="clusterName">friendly names chosen in the configuration section on the .config file</param>
        /// <returns>it returns a connection to work against the cluster.</returns>
        public static IClient RetrieveConnection(string clusterName)
        {
            return _instance.retrieveConnection(clusterName, null);
        }

        /// <summary>
        /// Retrieve a connection for cluster associated with the given clusterName. In case there is no cluster configured with the friendly name given, an AquilesException is thrown.
        /// <remarks>can throw <see cref="AquilesException"/> in case something went wrong</remarks>
        /// </summary>
        /// <param name="clusterName">friendly names chosen in the configuration section on the .config file</param>
        /// <param name="keyspace">name of the keyspace to connect to</param>
        /// <returns>it returns a connection to work against the cluster.</returns>
        public static IClient RetrieveConnection(string clusterName, string keyspace)
        {
            return _instance.retrieveConnection(clusterName, keyspace);
        }

        /// <summary>
        /// Read the configuration section, create logger, create clusters
        /// <remarks>can throw <see cref="AquilesException"/> in case something went wrong</remarks>
        /// </summary>
        public static void Initialize()
        {
            // do nothing, this is a trick for user clients
        }

        /// <summary>
        /// Retrieve a ICluster instance to work with.
        /// <remarks>can throw <see cref="AquilesException"/> in case something went wrong</remarks>
        /// </summary>
        /// <param name="clusterName">friendly names chosen in the configuration section on the .config file</param>
        /// <returns>it returns a cluster instance.</returns>
        public static ICluster RetrieveCluster(string clusterName)
        {
            return _instance.retrieveCluster(clusterName);
        }
        #endregion

        public AquilesHelper(AbstractAquilesClusterBuilder builder, string sectionConfigurationName)
        {
            CassandraConfigurationSection section = (CassandraConfigurationSection)ConfigurationManager.GetSection(sectionConfigurationName);
            if (section != null)
            {
                this.Clusters = BuildClusters(builder, section);
            }
            else
            {
                throw new AquilesConfigurationException("Configuration Section not found for '" + sectionConfigurationName + "'");
            }
        }

        public Dictionary<string, ICluster> Clusters
        {
            get;
            set;
        }

        public static Dictionary<string, ICluster> BuildClusters(AbstractAquilesClusterBuilder builder, CassandraConfigurationSection section)
        {
            Dictionary<string, ICluster> clusters = null;
            CassandraClusterCollection clusterCollection = section.CassandraClusters;
            if (clusterCollection != null && clusterCollection.Count > 0)
            {
                ICluster cluster = null;
                clusters = new Dictionary<string, ICluster>(clusterCollection.Count);
                foreach (CassandraClusterElement clusterConfig in section.CassandraClusters)
                {
                    try
                    {
                        cluster = builder.Build(clusterConfig);
                    }
                    catch (Exception e)
                    {
                        throw new AquilesConfigurationException("Exception found while creating clusters. See internal exception details.", e);
                    }
                    if (cluster != null)
                    {
                        if (!clusters.ContainsKey(cluster.Name))
                        {
                            clusters.Add(cluster.Name, cluster);
                        }
                    }
                }
            }
            else
            {
                throw new AquilesConfigurationException("Aquiles Configuration does not have any cluster configured.");
            }

            return clusters;
        }

        public ICluster retrieveCluster(string clusterName)
        {
            if (string.IsNullOrEmpty(clusterName))
                throw new ArgumentException("clusterName cannot be null nor empty");

            return this.Clusters[clusterName];
        }

        public IClient retrieveConnection(string clusterName, string keyspace)
        {
            ICluster cluster = this.retrieveCluster(clusterName);
            IClient client = null;

            if (cluster != null)
            {
                if (keyspace != null)
                {
                    client = cluster.Borrow(keyspace);
                }
                else
                {
                    client = cluster.Borrow();
                }
            }
            else
            {
                throw new AquilesException("Cluster not found by the name of '" + clusterName + "'");
            }
            return client;
        }
    }
}

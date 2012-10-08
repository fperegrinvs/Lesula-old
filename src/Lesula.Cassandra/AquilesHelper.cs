// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AquilesHelper.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//    http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the AquilesHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Cassandra
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

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
            Reset();
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
            var section = (CassandraConfigurationSection)ConfigurationManager.GetSection(sectionConfigurationName);
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
            {
                throw new ArgumentException("clusterName cannot be null nor empty");
            }

            return this.Clusters[clusterName];
        }
    }
}

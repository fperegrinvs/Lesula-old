namespace Lesula.Cassandra.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lesula.Cassandra.Cluster;
    using Lesula.Cassandra.Cluster.Factory;
    using Lesula.Cassandra.Connection.EndpointManager;
    using Lesula.Cassandra.Connection.EndpointManager.Factory;
    using Lesula.Cassandra.Connection.Factory;
    using Lesula.Cassandra.Connection.Pooling;
    using Lesula.Cassandra.Connection.Pooling.Factory;
    using Lesula.Cassandra.Model;
    using Lesula.Cassandra.Model.Impl;

    public abstract class AbstractAquilesClusterBuilder
    {
        public enum ClusterType
        {
            Default,
        }

        /// <summary>
        /// Type of ConnectionPool
        /// </summary>
        public enum PoolType
        {
            /// <summary>
            /// No pool is used. Clients are created based on need, they are disposed as soon as they are returned.
            /// </summary>
            NoPool = 0,

            /// <summary>
            /// Warmup enable and size-controlled enabled pool.
            /// </summary>
            SizeControlledPool = 1,

            /// <summary>
            /// Warmup enable and size-controlled enabled pool, divided by keyspaces.
            /// </summary>
            SizedKeyspacePool = 2

        }

        public enum EndpointManagerType
        {
            /// <summary>
            /// Cycle through the list of endpoints to balance the pool connections
            /// </summary>
            RoundRobin,
        }

        protected const string EndpointmanagerDuetimeKey = "endpointManagerDueTime";
        protected const string EndpointmanagerPeriodictimeKey = "endpointManagerPeriodicTime";
        protected const string PoolDuetimeKey = "poolDueTime";
        protected const string PoolPeriodictimeKey = "poolPeriodicTime";
        protected const string PoolMinimumClientsToKeepKey = "minimumClientsToKeepInPool";
        protected const string PoolMaximumClientsToSupportKey = "maximumClientsToSupportInPool";
        protected const string PoolMagicNumberKey = "magicNumber";
        protected const string PoolMaximumRetriesToPollClient = "maximumRetriesToPollClient";


        public virtual ICluster Build(CassandraClusterElement clusterConfig)
        {
            ICluster cluster = null;
            var clusterType = (ClusterType)Enum.Parse(typeof(ClusterType), clusterConfig.ClusterType, true);
            switch (clusterType)
            {
                case ClusterType.Default:
                    cluster = this.BuildDefaultCluster(clusterConfig);
                    break;
                default:
                    throw new NotImplementedException(string.Format("ClusterType '{0}' not implemented.", clusterType));
            }

            return cluster;
        }

        protected virtual ICluster BuildDefaultCluster(CassandraClusterElement clusterConfig)
        {
            var clusterFactory = new DefaultClusterFactory { FriendlyName = clusterConfig.FriendlyName };
            clusterFactory.PoolManager = this.buildPoolManager(clusterConfig, clusterFactory.FriendlyName);
            return clusterFactory.Create();
        }

        protected virtual IClientPool buildPoolManager(CassandraClusterElement clusterConfig, string clusterName)
        {
            IClientPool clientPool;
            ConnectionElement connectionConfig = clusterConfig.Connection;
            var poolType = (PoolType)Enum.Parse(typeof(PoolType), connectionConfig.PoolType, true);
            switch (poolType)
            {
                case PoolType.NoPool:
                    clientPool = this.buildNoClientPool(clusterConfig, clusterName);
                    break;
                case PoolType.SizeControlledPool:
                    clientPool = this.buildSizeControlledClientPool(clusterConfig, clusterName);
                    break;
                case PoolType.SizedKeyspacePool:
                    clientPool = this.BuildSizeKeyspaceControlledClientPool(clusterConfig, clusterName);
                    break;
                default:
                    throw new NotImplementedException(string.Format("PoolType '{0}' not implemented.", poolType));
            }

            return clientPool;
        }

        private IClientPool buildSizeControlledClientPool(CassandraClusterElement clusterConfig, string clusterName)
        {
            int intTempValue = 0;
            var poolFactory = new SizeControlledClientPoolFactory();
            poolFactory.Name = string.Concat(clusterName, "_sizeControlledPool");
            poolFactory.ClientFactory = this.buildClientFactory(clusterConfig);
            poolFactory.EndpointManager = this.buildEndpointManager(clusterConfig, poolFactory.Name);

            SpecialConnectionParameterElement specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolPeriodictimeKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.PeriodicTime = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMagicNumberKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MagicNumber = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMaximumClientsToSupportKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MaximumClientsToSupport = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMaximumRetriesToPollClient);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MaximumRetriesToPollClient = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMinimumClientsToKeepKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MinimumClientsToKeep = intTempValue;
            }
                 
            return poolFactory.Create();
        }

        private IClientPool BuildSizeKeyspaceControlledClientPool(CassandraClusterElement clusterConfig, string clusterName)
        {
            SpecialConnectionParameterElement specialConfig;
            int intTempValue = 0;
            var poolFactory = new SizeKespaceControlledClientPoolFactory();
            poolFactory.Name = string.Concat(clusterName, "_sizeKeyspaceControlledPool");
            poolFactory.ClientFactory = this.buildClientFactory(clusterConfig);
            poolFactory.EndpointManager = this.buildEndpointManager(clusterConfig, poolFactory.Name);

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolPeriodictimeKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.PeriodicTime = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMagicNumberKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MagicNumber = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMaximumClientsToSupportKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MaximumClientsToSupport = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMaximumRetriesToPollClient);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MaximumRetriesToPollClient = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, PoolMinimumClientsToKeepKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                poolFactory.MinimumClientsToKeep = intTempValue;
            }

            return poolFactory.Create();
        }

        protected virtual IEndpointManager buildEndpointManager(CassandraClusterElement clusterConfig, string poolName)
        {
            IEndpointManager endpointManager;
            var endpointManagerType = (EndpointManagerType)Enum.Parse(typeof(EndpointManagerType), clusterConfig.EndpointManager.Type, true);
            switch (endpointManagerType)
            {
                case EndpointManagerType.RoundRobin:
                    endpointManager = this.buildRoundRobinEndpointManager(clusterConfig, poolName);
                    break;
                default:
                    throw new NotImplementedException(string.Format("EndpointManagerType '{0}' not implemented.", endpointManagerType));
            }

            return endpointManager;
        }

        private IEndpointManager buildRoundRobinEndpointManager(CassandraClusterElement clusterConfig, string poolName)
        {
            var endpointManagerFactory = new RoundRobinEndpointManagerFactory();
            endpointManagerFactory.Name = string.Concat(poolName, "_endpointManager");
            endpointManagerFactory.ClientFactory = this.buildClientFactory(clusterConfig);
            endpointManagerFactory.Endpoints = this.buildEndpoints(clusterConfig.EndpointManager.CassandraEndpoints, clusterConfig.EndpointManager.DefaultTimeout);
            SpecialConnectionParameterElement specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, EndpointmanagerPeriodictimeKey);
            int intTempValue = 0;
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                endpointManagerFactory.DueTime = intTempValue;
            }

            specialConfig = retrieveSpecialParameter(clusterConfig.Connection.SpecialConnectionParameters, EndpointmanagerPeriodictimeKey);
            if (specialConfig != null && int.TryParse(specialConfig.Value, out intTempValue))
            {
                endpointManagerFactory.PeriodicTime = intTempValue;
            }

            return endpointManagerFactory.Create();
        }

        protected virtual List<IEndpoint> buildEndpoints(CassandraEndpointCollection cassandraEndpointCollection, int defaultTimeout)
        {
            return (
                from CassandraEndpointElement endpointConfig in cassandraEndpointCollection
                select this.buildEndpoint(endpointConfig, defaultTimeout)).ToList();
        }

        protected abstract IConnectionFactory buildClientFactory(CassandraClusterElement clusterConfig);

        protected virtual IEndpoint buildEndpoint(CassandraEndpointElement endpointConfig, int defaultTimeout)
        {
            DefaultEndpoint endpoint = new DefaultEndpoint();
            endpoint.Address = endpointConfig.Address;
            endpoint.Port = endpointConfig.Port;
            endpoint.Timeout = (endpointConfig.Timeout != 0) ? endpointConfig.Timeout : defaultTimeout;

            return endpoint;
        }

        private IClientPool buildNoClientPool(CassandraClusterElement clusterConfig, string clusterName)
        {
            NoClientPoolFactory poolFactory = new NoClientPoolFactory();
            poolFactory.Name = string.Concat(clusterName, "_noPool");
            poolFactory.ClientFactory = this.buildClientFactory(clusterConfig);
            poolFactory.EndpointManager = this.buildEndpointManager(clusterConfig, poolFactory.Name);
            //poolFactory.Logger = logger;

            return poolFactory.Create();
        }

        protected static SpecialConnectionParameterElement retrieveSpecialParameter(SpecialConnectionParameterCollection specialConnectionParameterCollection, string propertyKey)
        {
            SpecialConnectionParameterElement element = null;
            if (specialConnectionParameterCollection != null)
            {
                element = specialConnectionParameterCollection[propertyKey];
            }

            return element;
        }

    }
}

namespace Lesula.Cassandra.Cluster.Factory
{
    using Lesula.Cassandra;
    using Lesula.Cassandra.Cluster.Impl;
    using Lesula.Cassandra.Connection.Pooling;

    public class DefaultClusterFactory : IFactory<ICluster>
    {
        public IClientPool PoolManager
        {
            get;
            set;
        }

        public string FriendlyName
        {
            get;
            set;
        }

        #region IFactory<ICluster> Members

        public ICluster Create()
        {
            DefaultCluster cluster = new DefaultCluster();
            cluster.PoolManager = this.PoolManager;
            cluster.Name = FriendlyName;
            return cluster;
        }

        #endregion
    }
}

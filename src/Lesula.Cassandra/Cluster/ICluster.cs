namespace Lesula.Cassandra.Cluster
{
    using Lesula.Cassandra;

    using Lesula.Cassandra.Client;

    public interface ICluster
    {
        string Name
        {
            get;
        }

        IClient Borrow();
        IClient Borrow(string keyspaceName);
        void Release(IClient client);
        void Invalidate(IClient client);
        T Execute<T>(ExecutionBlock<T> command);
        T Execute<T>(ExecutionBlock<T> command, string keyspaceName);
    }
}

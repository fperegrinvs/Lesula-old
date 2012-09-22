namespace Lesula.Cassandra.Cluster.Impl
{
    using System;

    using Lesula.Cassandra;
    using Lesula.Cassandra.Client;
    using Lesula.Cassandra.Connection.Pooling;
    using Lesula.Cassandra.Exceptions;

    public class DefaultCluster : ICluster
    {
        public IClientPool PoolManager
        {
            get;
            set;
        }

        public int MaximumRetries
        {
            get;
            set;
        }

        public DefaultCluster()
        {
            this.MaximumRetries = 0;
        }

        #region ICluster Members

        public string Name { get; set; }

        public IClient Borrow()
        {
            return this.PoolManager.Borrow();
        }

        public IClient Borrow(string keyspaceName)
        {
            IClient client = this.PoolManager.Borrow(keyspaceName);
            if (client != null && client.KeyspaceName != keyspaceName)
            {
                client.KeyspaceName = keyspaceName;
            }
            return client;
        }

        public void Release(IClient client)
        {
            this.PoolManager.Release(client);
        }

        public void Invalidate(IClient client)
        {
            this.PoolManager.Invalidate(client);
        }

        public T Execute<T>(ExecutionBlock<T> executionBlock, string keyspaceName)
        {
            T rtnObject = default(T);
            int executionCounter = 0;
            IClient client = null;
            bool noException = false;
            bool isClientHealthy = true;
            Exception exception = null;
            do
            {
                exception = null;
                noException = false;
                isClientHealthy = true;
                client = BorrowClient(keyspaceName);

                if (client != null)
                {
                    try
                    {
                        rtnObject = client.Execute<T>(executionBlock);
                        noException = true;
                    }
                    catch (ExecutionBlockException ex)
                    {
                        exception = ex;
                        isClientHealthy = ex.IsClientHealthy;
                        if (!ex.ShouldRetry)
                        {
                            executionCounter = 0;
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        AquilesHelper.Reset();
                        throw;
                    }
                    finally
                    {
                        if (noException || isClientHealthy)
                        {
                            this.Release(client);
                        }
                        else
                        {
                            this.Invalidate(client);
                        }
                    }
                }
                else
                {
                    AquilesHelper.Reset();
                    throw new AquilesException("No client could be borrowed.");
                }

                executionCounter++;
            }
            while (executionCounter < this.MaximumRetries && !noException);

            if (exception != null)
            {
                throw exception;
            }

            return rtnObject;
        }

        public T Execute<T>(ExecutionBlock<T> executionBlock)
        {
            return this.Execute<T>(executionBlock, null);
        }

        #endregion

        private IClient BorrowClient(string keyspaceName)
        {
            IClient client = null;
            if (keyspaceName != null)
            {
                client = this.Borrow(keyspaceName);
            }
            else
            {
                client = this.Borrow();
            }
            return client;
        }
    }
}

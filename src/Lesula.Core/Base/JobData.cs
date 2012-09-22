namespace Lesula.Core.Base
{
    using System;

    using Lesula.JobContracts.Cassandra;

    public abstract class JobData
    {
        public virtual byte[] Key { get; private set; }

        public virtual IRow ToRow()
        {
            throw new NotImplementedException();
        }

        public virtual JobData FromRow(IRow row)
        {
            throw new NotImplementedException();
        }
    }
}

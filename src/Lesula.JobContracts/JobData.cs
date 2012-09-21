namespace Lesula.JobContracts
{
    using System;

    using Lesula.JobContracts.Cassandra;

    public abstract class JobData<T>
    {
        public T Key { get; set; }

        public virtual IRow ToRow()
        {
            throw new NotImplementedException();
        }

        public virtual JobData<T> FromRow(IRow row)
        {
            throw new NotImplementedException();
        }
    }
}

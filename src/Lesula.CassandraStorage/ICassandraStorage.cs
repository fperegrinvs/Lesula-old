namespace Lesula.JobContracts
{
    using System.Collections.Generic;

    using Lesula.JobContracts.Cassandra;

    public interface ICassandraStorage
    {
        IList<IRow> SelectItems(string keyspace, string columnFamily, IList<IIndexExpression> filter, IRange range, ConsistencyLevel consistencyLevel);

        IRow GetRow(string keyspace, string columnFamily, byte[] rowKey, IRange range, ConsistencyLevel consistencyLevel);

        bool SaveRow(string keyspace, string columnFamily, IRow row, ConsistencyLevel consistencyLevel);

        bool SaveRows(string keyspace, string columnFamily, IList<IRow> rows, ConsistencyLevel consistencyLevel);
    }
}

namespace Lesula.JobContracts
{
    using System.Collections.Generic;

    using Lesula.CassandraStorage;
    using Lesula.JobContracts.Cassandra;

    public interface ICassandraStorage
    {
        IList<IRow> SelectItems(string keyspace, string columnFamily, IList<IIndexExpression> filter, IRange range, IColumnSlice slice, ConsistencyLevel consistencyLevel, ColumnType type = ColumnType.Column);

        IRow GetRow(string keyspace, string columnFamily, byte[] rowKey, IRange range, IColumnSlice slice, ConsistencyLevel consistencyLevel, ColumnType type = ColumnType.Column);

        bool SaveRow(string keyspace, string columnFamily, IRow row, ConsistencyLevel consistencyLevel, ColumnType type = ColumnType.Column);

        bool SaveRows(string keyspace, string columnFamily, IList<IRow> rows, ConsistencyLevel consistencyLevel, ColumnType type = ColumnType.Column);
    }
}

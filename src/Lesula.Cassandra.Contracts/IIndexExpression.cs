namespace Lesula.JobContracts.Cassandra
{
    public interface IIndexExpression
    {
        byte[] ColumnName { get; set; }

        IndexOperator Operator { get; set; }

        byte[] Value { get; set; }
    }
}

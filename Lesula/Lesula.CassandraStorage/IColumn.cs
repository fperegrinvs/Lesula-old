namespace Lesula.JobContracts.Cassandra
{
    public interface IColumn
    {
        byte[] Name { get; set; }

        byte[] Value { get; set; }
    }
}

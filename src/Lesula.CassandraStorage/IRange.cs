namespace Lesula.JobContracts.Cassandra
{
    public interface IRange
    {
        byte[] StartToken { get; set; }

        byte[] EndToken { get; set; }

        int Count { get; set; }
    }
}

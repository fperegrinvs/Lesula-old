namespace Lesula.JobContracts.Cassandra
{
    /// <summary>
    /// The consistency level.
    /// </summary>
    public enum ConsistencyLevel
    {
        ONE = 1,
        QUORUM = 2,
        LOCAL_QUORUM = 3,
        EACH_QUORUM = 4,
        ALL = 5,
        ANY = 6,
        TWO = 7,
        THREE = 8,
    }
}

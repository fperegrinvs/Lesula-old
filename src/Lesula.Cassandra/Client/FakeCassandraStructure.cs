namespace Lesula.Cassandra.Client
{
    using System.Collections.Concurrent;

    using Apache.Cassandra;

    public static class FakeCassandraStructure
    {
        public static string CurrentKeyspace { get; set; }

        /// <summary>
        /// The keyspaces.
        /// </summary>
        public static ConcurrentDictionary<string, KeyspaceStructure> Keyspaces = new ConcurrentDictionary<string, KeyspaceStructure>();
    }

    public class KeyspaceStructure
    {
        public ConcurrentDictionary<string, ColumnFamilyStructure> ColumnFamilies = new ConcurrentDictionary<string, ColumnFamilyStructure>(); 
    }

    public enum CFType
    {
        Column,
        SuperColumn,
        CounterColumn,
        SuperCounterColumn
    }

    public class ColumnFamilyStructure
    {
        public CFType FamilyType { get; set; }

        public ConcurrentDictionary<string, RowStructure> Rows = new ConcurrentDictionary<string, RowStructure>();
        public ConcurrentDictionary<string, SuperRowStructure> SuperRows = new ConcurrentDictionary<string, SuperRowStructure>();
        public ConcurrentDictionary<string, CounterRowStructure> CounterRows = new ConcurrentDictionary<string, CounterRowStructure>();
        public ConcurrentDictionary<string, SuperCounterRowStructure> SuperCounterRows = new ConcurrentDictionary<string, SuperCounterRowStructure>();
    }

    public class RowStructure
    {
        public string Key { get; set; }
        public ConcurrentDictionary<string, Column> Columns = new ConcurrentDictionary<string, Column>(); 
    }

    public class SuperRowStructure
    {
        public string Key { get; set; }
        public ConcurrentDictionary<string, SuperColumn> Columns = new ConcurrentDictionary<string, SuperColumn>();
    }

    public class CounterRowStructure
    {
        public string Key { get; set; }
        public ConcurrentDictionary<string, CounterColumn> Columns = new ConcurrentDictionary<string, CounterColumn>();
    }

    public class SuperCounterRowStructure
    {
        public string Key { get; set; }
        public ConcurrentDictionary<string, CounterSuperColumn> Columns = new ConcurrentDictionary<string, CounterSuperColumn>();
    }

}

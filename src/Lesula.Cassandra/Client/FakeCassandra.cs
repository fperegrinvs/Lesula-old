namespace Lesula.Cassandra.Client
{
    using System;
    using System.Collections.Generic;

    using Apache.Cassandra;

    public class FakeCassandra : Cassandra.Iface
    {
        public void login(AuthenticationRequest auth_request)
        {
            throw new NotImplementedException();
        }

        public void set_keyspace(string keyspace)
        {
            throw new NotImplementedException();
        }

        public ColumnOrSuperColumn get(byte[] key, ColumnPath column_path, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public List<ColumnOrSuperColumn> get_slice(byte[] key, ColumnParent column_parent, SlicePredicate predicate, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public int get_count(byte[] key, ColumnParent column_parent, SlicePredicate predicate, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public Dictionary<byte[], List<ColumnOrSuperColumn>> multiget_slice(List<byte[]> keys, ColumnParent column_parent, SlicePredicate predicate, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public Dictionary<byte[], int> multiget_count(List<byte[]> keys, ColumnParent column_parent, SlicePredicate predicate, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public List<KeySlice> get_range_slices(ColumnParent column_parent, SlicePredicate predicate, KeyRange range, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public List<KeySlice> get_paged_slice(string column_family, KeyRange range, byte[] start_column, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public List<KeySlice> get_indexed_slices(ColumnParent column_parent, IndexClause index_clause, SlicePredicate column_predicate, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public void insert(byte[] key, ColumnParent column_parent, Column column, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public void add(byte[] key, ColumnParent column_parent, CounterColumn column, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public void remove(byte[] key, ColumnPath column_path, long timestamp, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public void remove_counter(byte[] key, ColumnPath path, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public void batch_mutate(Dictionary<byte[], Dictionary<string, List<Mutation>>> mutation_map, ConsistencyLevel consistency_level)
        {
            throw new NotImplementedException();
        }

        public void truncate(string cfname)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<string>> describe_schema_versions()
        {
            throw new NotImplementedException();
        }

        public List<KsDef> describe_keyspaces()
        {
            throw new NotImplementedException();
        }

        public string describe_cluster_name()
        {
            throw new NotImplementedException();
        }

        public string describe_version()
        {
            throw new NotImplementedException();
        }

        public List<TokenRange> describe_ring(string keyspace)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> describe_token_map()
        {
            throw new NotImplementedException();
        }

        public string describe_partitioner()
        {
            throw new NotImplementedException();
        }

        public string describe_snitch()
        {
            throw new NotImplementedException();
        }

        public KsDef describe_keyspace(string keyspace)
        {
            throw new NotImplementedException();
        }

        public List<string> describe_splits(string cfName, string start_token, string end_token, int keys_per_split)
        {
            throw new NotImplementedException();
        }

        public string system_add_column_family(CfDef cf_def)
        {
            throw new NotImplementedException();
        }

        public string system_drop_column_family(string column_family)
        {
            throw new NotImplementedException();
        }

        public string system_add_keyspace(KsDef ks_def)
        {
            throw new NotImplementedException();
        }

        public string system_drop_keyspace(string keyspace)
        {
            throw new NotImplementedException();
        }

        public string system_update_keyspace(KsDef ks_def)
        {
            throw new NotImplementedException();
        }

        public string system_update_column_family(CfDef cf_def)
        {
            throw new NotImplementedException();
        }

        public CqlResult execute_cql_query(byte[] query, Compression compression)
        {
            throw new NotImplementedException();
        }

        public CqlPreparedResult prepare_cql_query(byte[] query, Compression compression)
        {
            throw new NotImplementedException();
        }

        public CqlResult execute_prepared_cql_query(int itemId, List<byte[]> values)
        {
            throw new NotImplementedException();
        }

        public void set_cql_version(string version)
        {
            throw new NotImplementedException();
        }
    }
}

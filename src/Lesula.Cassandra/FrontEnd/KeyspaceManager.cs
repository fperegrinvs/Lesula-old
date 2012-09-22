namespace Lesula.Cassandra.FrontEnd
{
    using System.Collections.Generic;

    using Apache.Cassandra;

    using Lesula.Cassandra;
    using Lesula.Cassandra.Cluster;

    /// <summary>
    /// Management operations need to be applied to a single node.
    /// See http://wiki.apache.org/cassandra/LiveSchemaUpdates for more details.
    /// </summary>
    public class KeyspaceManager
    {

        public const string KsdefStrategySimple = "org.apache.cassandra.locator.SimpleStrategy";
        public const string KsdefStrategyLocal = "org.apache.cassandra.locator.LocalStrategy";
        public const string KsdefStrategyNetworkTopology = "org.apache.cassandra.locator.NetworkTopologyStrategy";
        public const string KsdefStrategyNetworkTopologyOld = "org.apache.cassandra.locator.OldNetworkTopologyStrategy";

        /// <summary>
        /// The cluster.
        /// </summary>
        private readonly ICluster cluster;

        public KeyspaceManager(ICluster cluster)
        {
            this.cluster = cluster;
        }

        public List<KsDef> GetKeyspaceNames()
        {
            var operation = new ExecutionBlock<List<KsDef>>(myclient => myclient.describe_keyspaces());
            return this.cluster.Execute(operation);
        }

        public List<TokenRange> GetKeyspaceRingMappings(string keyspace)
        {
            var operation = new ExecutionBlock<List<TokenRange>>(myclient => myclient.describe_ring(keyspace));
            return this.cluster.Execute(operation);
        }

        public KsDef GetKeyspaceSchema(string keyspace)
        {
            var operation = new ExecutionBlock<KsDef>(myclient => myclient.describe_keyspace(keyspace));
            return this.cluster.Execute(operation);
        }

        public string AddKeyspace(string name, int replicationFactor)
        {
            var keyDefinition = new KsDef
                {
                    Name = name,
                    Replication_factor = replicationFactor,
                    Strategy_class = KsdefStrategySimple,
                    Cf_defs = new List<CfDef>()
                };
            return AddKeyspace(keyDefinition);
        }

        /// <summary>
        /// Atualiza configurações de um keyspace
        /// </summary>
        /// <param name="keyspaceDefinition">definições do keyspace</param>
        /// <returns>id do schema</returns>
        public string UpdateKeyspace(KsDef keyspaceDefinition)
        {
            var operation = new ExecutionBlock<string>(myclient => myclient.system_update_keyspace(keyspaceDefinition));
            return this.cluster.Execute(operation);
        }

        /// <summary>
        /// Descreve um keyspace
        /// </summary>
        /// <param name="name">nome do keyspace</param>
        /// <returns>Descrição do keyspace</returns>
        public KsDef DescribeKeyspace(string name)
        {
            var operation = new ExecutionBlock<KsDef>(myclient => myclient.describe_keyspace(name));
            return this.cluster.Execute(operation);
        }

        public string AddKeyspace(KsDef keyspaceDefinition)
        {
            var operation = new ExecutionBlock<string>(myclient => myclient.system_add_keyspace(keyspaceDefinition));
            return this.cluster.Execute(operation);
        }

        public string DropKeyspace(string keyspace)
        {
            var operation = new ExecutionBlock<string>(myclient => myclient.system_drop_keyspace(keyspace));
            return this.cluster.Execute(operation);
        }
    }
}

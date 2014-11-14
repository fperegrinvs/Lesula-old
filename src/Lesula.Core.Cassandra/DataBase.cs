// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBase.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//    http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   The data base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Core.Cassandra
{
    using System.Collections.Generic;

    using Apache.Cassandra;

    using Lesula.Cassandra;
    using Lesula.Cassandra.Cluster;
    using Lesula.Cassandra.FrontEnd;
    using Lesula.Cassandra.FrontEnd.Enumerators;

    /// <summary>
    /// The data base.
    /// </summary>
    public class DataBase : IDataBase
    {
        /// <summary>
        /// Construtor para facilitar a criação de um mutator.
        /// </summary>
        /// <param name="ttl">
        /// The ttl.
        /// </param>
        /// <returns>
        /// Mutator pronto para ser utilizado.
        /// </returns>
        public static Mutator CreateMutator(int ttl = Mutator.NoTtl)
        {
            return new Mutator(GetCluster(), Context.Config.Get("Keyspace"), ttl);
        }

        /// <summary>
        /// Construtor para facilitar a criação de um RowDeletor.
        /// </summary>
        /// <returns>
        /// RowDeletor pronto para ser utilizado.
        /// </returns>
        public static RowDeletor CreateRowDeletor()
        {
            return new RowDeletor(GetCluster(), Context.Config.Get("Keyspace"));
        }

        /// <summary>
        /// Construtor para facilitar a criação de um Selector.
        /// </summary>
        /// <returns>
        /// Selector pronto para ser utilizado.
        /// </returns>
        public static Selector CreateSelector()
        {
            return new Selector(GetCluster(), Context.Config.Get("Keyspace"));
        }

        /// <summary>
        /// Create database structure
        /// </summary>
        public List<string> CreateStructure()
        {
            var msgs = new List<string>();
            var keyspace = Context.Config.Get("Keyspace");
            var connection = GetCluster();
            var manager = new KeyspaceManager(connection);
            manager.TryAddKeyspace(keyspace, int.Parse(Context.Config.Get("Replication")));

            var famManager = new ColumnFamilyManager(connection, keyspace);
            famManager.TryAddColumnFamily("Machine", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type);
            famManager.TryAddColumnFamily("User", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type);
            famManager.TryAddColumnFamily("Status", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type);
            famManager.TryAddColumnFamily("Task", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type);
            famManager.TryAddColumnFamily("DataType", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type);
            famManager.TryAddColumnFamily("DataSource", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type);
            
            var columnDefs = new List<ColumnDef>
                {
                    ColumnFamilyManager.NewColumnDefinition("RootId", true, ComparatorTypeEnum.BytesType),
                };
            famManager.TryAddColumnFamily("JobConfig", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type, columnDefs: columnDefs);

            columnDefs = new List<ColumnDef>
                {
                    ColumnFamilyManager.NewColumnDefinition("STA", true, ComparatorTypeEnum.BytesType), // status
                };
            famManager.TryAddColumnFamily("ScheduledJobs", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type, columnDefs: columnDefs);
            famManager.TryAddColumnFamily("JobTracker", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type, columnDefs: columnDefs);

            columnDefs = new List<ColumnDef>
                {
                    ColumnFamilyManager.NewColumnDefinition("JID", true, ComparatorTypeEnum.BytesType), // jobid
                    ColumnFamilyManager.NewColumnDefinition("BID", true, ComparatorTypeEnum.BytesType), // bucket id
                };
            famManager.TryAddColumnFamily("JobData", ColumnTypeEnum.Standard, ComparatorTypeEnum.UTF8Type, columnDefs: columnDefs);
            return msgs;
        }

        /// <summary>
        /// Delete database structure
        /// </summary>
        /// <returns>errors</returns>
        public List<string> CleanStructure()
        {
            var keyspace = Context.Config.Get("Keyspace");

            var msgs = new List<string>();
            var connection = GetCluster();
            var manager = new KeyspaceManager(connection);
            manager.DropKeyspace(keyspace);
            return msgs;
        }

        /// <summary>
        /// Default cluster
        /// </summary>
        /// <returns>
        /// The Lesula.Cassandra.Cluster.ICluster.
        /// </returns>
        internal static ICluster GetCluster()
        {
            var defaultCluster = Context.Config.Get("DefaultCluster");
            return AquilesHelper.RetrieveCluster(defaultCluster);
        }
    }
}

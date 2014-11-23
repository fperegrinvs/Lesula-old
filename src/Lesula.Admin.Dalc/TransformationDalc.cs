// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobDalc.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The data source dalc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Dalc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Apache.Cassandra;

    using Lesula.Admin.Contracts;
    using Lesula.Cassandra;
    using Lesula.Cassandra.FrontEnd;
    using Lesula.Client.Contracts.Models;
    using Lesula.Core.Cassandra;

    /// <summary>
    /// The data source dalc.
    /// </summary>
    public class TransformationDalc : ITransformationDalc
    {
        public DataTransformation GetTransformation(Guid id)
        {
            var selector = DataBase.CreateSelector();
            var columns = selector.GetColumnFromRow("JobConfig", id, "DAT", ConsistencyLevel.ONE);
            var user = this.MapFromColumn(columns);
            return user;
        }

        private DataTransformation MapFromColumn(Column column)
        {
            var decompressed = LZ4Sharp.LZ4.Decompress(column.Value).ToUtf8String();
            var data = ServiceStack.Text.TypeSerializer.DeserializeFromString<DataTransformation>(decompressed);
            return data;
        }

        public string SaveTransformation(DataTransformation dataType)
        {
            var serialized = ServiceStack.Text.TypeSerializer.SerializeToString(dataType);
            var compressed = LZ4Sharp.LZ4.Compress(serialized.ToBytes());

            var mutator = DataBase.CreateMutator();
            var column = mutator.NewColumn("DAT", compressed);
            mutator.InsertColumn("JobConfig", dataType.Id.ToByteArray(), column, ConsistencyLevel.ONE);
            return "";
        }

        public List<DataTransformation> GetAllTransformations()
        {
            var selector = DataBase.CreateSelector();
            var rows = selector.GetColumnsFromRows("JobConfig", Selector.KeyRangeAll, Selector.NewColumnsPredicate("DAT"), ConsistencyLevel.ONE);
            var data = rows.Select(row => this.MapFromColumn(row.Value[0])).ToList();
            return data;
        }
    }
}

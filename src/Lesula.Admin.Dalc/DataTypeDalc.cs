// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTypeDalc.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the DataTypeDalc type.
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

    /// <summary>
    /// The data type dalc.
    /// </summary>
    public class DataTypeDalc : IDataTypeDalc
    {
        /// <summary>
        /// The get data type.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The Lesula.Client.Contracts.Models.DataType.
        /// </returns>
        public DataType GetDataType(Guid id)
        {
            var selector = DataBase.CreateSelector();
            var columns = selector.GetColumnFromRow("DataType", id, "DAT", ConsistencyLevel.ONE);
            var user = this.MapFromColumn(columns);
            return user;
        }

        /// <summary>
        /// The save data type.
        /// </summary>
        /// <param name="dataType">
        /// The data type.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SaveDataType(DataType dataType)
        {
            var serialized = ServiceStack.Text.TypeSerializer.SerializeToString(dataType);
            var compressed = LZ4Sharp.LZ4.Compress(serialized.ToBytes());

            var mutator = DataBase.CreateMutator();
            var column = mutator.NewColumn("DAT", compressed);
            mutator.InsertColumn("DataType", dataType.Id.ToByteArray(), column, ConsistencyLevel.ONE);
        }

        public List<DataType> GetAllDataTypes()
        {
            var selector = DataBase.CreateSelector();
            var rows = selector.GetColumnsFromRows("DataType", Selector.KeyRangeAll, Selector.NewColumnsPredicate("DAT"), ConsistencyLevel.ONE);
            var data = rows.Select(row => this.MapFromColumn(row.Value[0])).ToList();
            return data;
        }

        /// <summary>
        /// Map data column to User
        /// </summary>
        /// <param name="column">
        /// Column
        /// </param>
        /// <returns>
        /// Resulting data type
        /// </returns>
        private DataType MapFromColumn(Column column)
        {
            var decompressed = LZ4Sharp.LZ4.Decompress(column.Value).ToUtf8String();
            var data = ServiceStack.Text.TypeSerializer.DeserializeFromString<DataType>(decompressed);
            return data;
        }
    }
}

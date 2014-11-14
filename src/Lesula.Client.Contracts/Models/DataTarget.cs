// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSource.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The data source.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Lesula.Client.Contracts.Enumerators;

    /// <summary>
    /// The data target.
    /// </summary>
    public class DataTarget
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Friendly name
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Source type
        /// </summary>
        [DisplayName("Target Kind")]
        public TargetKind TargetKind { get; set; }

        /// <summary>
        /// Type of the data
        /// </summary>
        [DisplayName("Data Type")]
        public Guid DataType { get; set; }

        /// <summary>
        /// Job Target
        /// </summary>
        [DisplayName("Target Job")]
        public Guid? JobId { get; set; }

        /// <summary>
        /// Cluster Id
        /// </summary>
        [DisplayName("Cluster Alias")]
        public string ClusterId { get; set; }

        /// <summary>
        /// Source keyspace (SourceKind = Query)
        /// </summary>
        public string Keyspace { get; set; }

        /// <summary>
        /// Column Family (SourceKind = Query)
        /// </summary>
        public string ColumnFamily { get; set; }

        /// <summary>
        /// Query consistency level
        /// </summary>
        [DisplayName("Consistency level")]
        public ConsistencyLevel ConsistencyLevel { get; set; }

        /// <summary>
        /// Source is compressed ?
        /// </summary>
        [DisplayName("Target is compressed using which format ?")]
        public CompressionFormat CompressionFormat { get; set; }

        /// <summary>
        /// Data is serialized ? 
        /// Using what format ?
        /// </summary>
        [DisplayName("Target is serialized using which format ?")]
        public SerializationFormat SerializationFormat { get; set; }
    }
}

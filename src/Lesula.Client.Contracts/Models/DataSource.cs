﻿// --------------------------------------------------------------------------------------------------------------------
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

    using Lesula.Client.Contracts.Enumerators;

    /// <summary>
    /// The data source.
    /// </summary>
    public class DataSource
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
        public SourceType SourceType { get; set; }

        /// <summary>
        /// Source from job
        /// </summary>
        public Guid? JobId { get; set; }

        /// <summary>
        /// Source keyspace (SourceType = Query)
        /// </summary>
        public string Keyspace { get; set; }

        /// <summary>
        /// Gets or sets the column family.
        /// </summary>
        public string ColumnFamily { get; set; }

        /// <summary>
        /// Source column type
        /// </summary>
        [DisplayName("Source column type")]
        public ColumnType ColumnType { get; set; }

        /// <summary>
        /// Slice type
        /// </summary>
        [DisplayName("Column Slice Type")]
        public ColumnSliceType SliceType { get; set; }

        /// <summary>
        /// Columns to select
        /// </summary>
        [DisplayName("Custom column slice")]
        public ColumnSlice CustomColumnSlice { get; set; }

        /// <summary>
        /// Query filters
        /// </summary>
        [DisplayName("Query filters")]
        public List<QueryFilter> Filters { get; set; }

        /// <summary>
        /// Query consistency level
        /// </summary>
        [DisplayName("Consistency level")]
        public ConsistencyLevel? ConsistencyLevel { get; set; }

        /// <summary>
        /// Source is compressed using IZ4 ?
        /// </summary>
        [DisplayName("Source is compressed using which format ?")]
        public CompressionFormat CompressionFormat { get; set; }

        /// <summary>
        /// Data is serialized ? 
        /// Using what format ?
        /// </summary>
        [DisplayName("Source is serialized using which format ?")]
        public SerializationFormat SerializationFormat { get; set; }
    }
}

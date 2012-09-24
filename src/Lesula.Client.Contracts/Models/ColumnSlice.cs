// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnSlice.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the ColumnSlice type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The column slice.
    /// </summary>
    public class ColumnSlice
    {
        /// <summary>
        /// Gets or sets the start column.
        /// </summary>
        public string StartColumn { get; set; }

        /// <summary>
        /// Gets or sets the end column.
        /// </summary>
        public string EndColumn { get; set; }

        /// <summary>
        /// Gets or sets the column names.
        /// </summary>
        public IList<string> ColumnNames { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether reverse.
        /// </summary>
        public bool Reverse { get; set; }
    }
}

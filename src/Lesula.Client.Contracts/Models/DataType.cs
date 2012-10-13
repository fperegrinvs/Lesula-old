// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataType.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Datatype used in map/reduce
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Datatype used in map/reduce
    /// </summary>
    public class DataType
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Friendly name
        /// </summary>
        [Required]
        [DisplayName("Friendly Name")]
        public string Name { get; set; }

        /// <summary>
        /// Class definition
        /// </summary>
        public string Code { get; set; }
    }
}

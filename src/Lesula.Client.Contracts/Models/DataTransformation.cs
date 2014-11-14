// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Job.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The job.
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
    /// The job.
    /// </summary>
    public class DataTransformation
    {
        /// <summary>
        /// Unique DT id
        /// </summary>
        [ReadOnly(true)]
        public Guid Id { get; set; }

        /// <summary>
        /// Job friendly name
        /// </summary>
        [Required]
        [DisplayName("Friendly Name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the job
        /// </summary>
        [Required]
        [DisplayName("Type")]
        public TransformationType JobType { get; set; }

        /// <summary>
        /// Code used in this DT
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// List of DT that must complete before this one
        /// </summary>
        [DisplayName("Transformations that must complete before this one can execute")]
        [UIHint("DependencyList")]
        public List<Dependency> Dependency { get; set; }
    }
}
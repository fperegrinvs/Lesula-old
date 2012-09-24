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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The job.
    /// </summary>
    public class Job
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The task container
        /// </summary>
        public Guid TaskId { get; set; }

        /// <summary>
        /// List of job that must complete before this one
        /// </summary>
        public List<Guid> Dependency { get; set; }

        [Required]
        public string Name { get; set; }

        public JobOptions Options { get; set; }
    }
}
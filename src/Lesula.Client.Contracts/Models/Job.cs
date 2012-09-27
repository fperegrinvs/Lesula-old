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
    public class Job
    {
        /// <summary>
        /// Unique job id
        /// </summary>
        [ReadOnly(true)]
        public Guid Id { get; set; }

        /// <summary>
        /// The task container
        /// </summary>
        public Guid TaskId { get; set; }

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
        public JobType JobType { get; set; }

        /// <summary>
        /// Code used in this job
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// List of job that must complete before this one
        /// </summary>
        [DisplayName("Jobs that must complete before this job can execute")]
        public List<Guid> Dependency { get; set; }

        /// <summary>
        /// Where job output goes
        /// </summary>
        [Required]
        [DisplayName("Output target")]
        public OutputDestination OutputDestination { get; set; }

        /// <summary>
        /// Output data format
        /// </summary>
        [Required]
        [DisplayName("Output Format")]
        public DataType OutputFormat { get; set; }

        /// <summary>
        /// Job obtions
        /// </summary>
        public JobOptions Options { get; set; }
    }
}
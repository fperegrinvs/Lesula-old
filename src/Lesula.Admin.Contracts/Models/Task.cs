namespace Lesula.Core.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Set of MapReduce Jobs
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Job Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Friendly name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Who changed the job
        /// </summary>
        [DisplayName("Changed By")]
        public string ChangedBy { get; set; }

        /// <summary>
        /// Who changed the job
        /// </summary>
        [DisplayName("Changed Date")]
        public DateTime ChangedDate { get; set; }
    }
}
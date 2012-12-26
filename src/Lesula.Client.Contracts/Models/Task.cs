namespace Lesula.Client.Contracts.Models
{
    using System;

    using Lesula.Client.Contracts.Enumerators;

    /// <summary>
    /// A task is an instance of a job
    /// </summary>
    public class Task
    {
        /// <summary>
        /// The task unique Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The job id
        /// </summary>
        public Guid JobId { get; set; }

        /// <summary>
        /// Friendly name for the task
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// When the task entered in the queue
        /// </summary>
        public DateTime QueueDate { get; set; }

        /// <summary>
        /// Task start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// task finish date
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// Task progress (%)
        /// </summary>
        public int PercentCompleted { get; set; }

        /// <summary>
        /// Status of the task
        /// </summary>
        public TaskStatus Status { get; set; }
    }
}

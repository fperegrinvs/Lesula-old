namespace Lesula.Client.Services
{
    using System;

    using Lesula.Client.Contracts.Models;

    /// <summary>
    /// Task and slots service
    /// </summary>
    public class TaskService
    {
        /// <summary>
        /// default instance
        /// </summary>
        private static TaskService instance = new TaskService();

        /// <summary>
        /// Gets or sets the default instance.
        /// </summary>
        public static TaskService DefaultInstance
        {
            get
            {
                return instance ?? (instance = new TaskService());
            }

            set
            {
                instance = value;
            }
        }


        /// <summary>
        /// Get a segment to be processed
        /// </summary>
        /// <returns>segment to be processed</returns>
        public Segment GetSegment()
        {
            throw new NotImplementedException();
        }
    }
}

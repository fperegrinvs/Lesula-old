namespace Lesula.Client.Contracts.Enumerators
{
    /// <summary>
    /// Status of a task
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Waiting execution
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// Currently running
        /// </summary>
        Running = 1,

        /// <summary>
        /// Finished sucessfully
        /// </summary>
        Sucess = 2,

        /// <summary>
        /// Failed to complete
        /// </summary>
        Failed = 3,
    }
}

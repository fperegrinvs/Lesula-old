namespace Lesula.Client.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// The TaskDalc interface.
    /// </summary>
    public interface ITaskDalc
    {
        /// <summary>
        /// Get a current list of running and queued tasks
        /// </summary>
        /// <returns>list of running and queued tasks</returns>
        List<ITaskDalc> GetTaskList();
    }
}

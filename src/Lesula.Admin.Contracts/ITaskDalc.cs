// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskDalc.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the ITaskDalc type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Contracts
{
    using System;
    using System.Collections.Generic;

    using Lesula.Admin.Contracts.Models;

    /// <summary>
    /// The TaskDalc interface.
    /// </summary>
    public interface ITaskDalc
    {
        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns>
        /// List of all tasks.
        /// </returns>
        List<Task> GetAll();

        /// <summary>
        /// Get task info
        /// </summary>
        /// <param name="taskId">task id</param>
        /// <returns>requested task info</returns>
        Task Get(Guid taskId);

        /// <summary>
        /// Save task
        /// </summary>
        /// <param name="task">task data</param>
        void Save(Task task);

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="taskId">task id</param>
        void Delete(Guid taskId);
    }
}

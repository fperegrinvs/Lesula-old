// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   IOC Helper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Dalc
{
    using Lesula.Admin.Contracts;
    using Lesula.Core;
    using Lesula.Core.Cassandra;

    /// <summary>
    /// IOC Helper
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Registers all classes in the ioc container
        /// </summary>
        public static void RegisterAll()
        {
            Context.Container.Register<IDataBase>(c => new DataBase());
            Context.Container.Register<ITaskDalc>(c => new TaskDalc());
            Context.Container.Register<IUserDalc>(c => new UserDalc());
            Context.Container.Register<IDataTypeDalc>(c => new DataTypeDalc());
            Context.Container.Register<IDataSourceDalc>(c => new DataSourceDalc());
            Context.Container.Register<IJobDalc>(c => new JobDalc());
        }
    }
}

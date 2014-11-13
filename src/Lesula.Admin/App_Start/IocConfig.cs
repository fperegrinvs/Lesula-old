// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IocConfig.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The ioc config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.App_Start
{
    using Lesula.CodeParser;
    using Lesula.Core;

    /// <summary>
    /// The ioc config.
    /// </summary>
    public class IocConfig
    {
        /// <summary>
        /// Configure IOC
        /// </summary>
        public static void ConfigureIoC()
        {
            // base services
            Context.Container.Register<IContext>(c => ThreadContext.CreateInstance());
            Context.Container.Register<IConfigSettings>(c => new AppConfigSettings());

            // admin dalc
            Dalc.Register.RegisterAll();

            // assembly generator
            Context.Container.Register<IAssemblyGenerator>(c => new AssemblyGenerator());
        }
    }
}
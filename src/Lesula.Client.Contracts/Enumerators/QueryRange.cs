// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryRange.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The query range.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Enumerators
{
    using System.ComponentModel;

    /// <summary>
    /// The query range.
    /// </summary>
    public enum QueryRange
    {
        /// <summary>
        /// Same range as job
        /// </summary>
        [Description("Job Range")]
        JobRange = 1,

        /// <summary>
        /// All column family
        /// </summary>
        [Description("All items")]
        FullRange = 2,
    }
}

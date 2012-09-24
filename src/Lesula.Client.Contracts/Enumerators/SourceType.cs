﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceType.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The source type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Enumerators
{
    /// <summary>
    /// The source type.
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// Source from Job
        /// </summary>
        Job = 1,

        /// <summary>
        /// Source from code
        /// </summary>
        Code = 2,
    }
}
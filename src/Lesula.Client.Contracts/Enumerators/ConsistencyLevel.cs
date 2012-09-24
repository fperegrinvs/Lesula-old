// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsistencyLevel.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The consistency level.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Enumerators
{
    /// <summary>
    /// The consistency level.
    /// </summary>
    public enum ConsistencyLevel
    {
        ONE = 1,
        QUORUM = 2,
        LOCAL_QUORUM = 3,
        EACH_QUORUM = 4,
        ALL = 5,
        ANY = 6,
        TWO = 7,
        THREE = 8,
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndexOperator.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   The index operator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Cassandra.Contracts
{
    /// <summary>
    /// The index operator.
    /// </summary>
    public enum IndexOperator
    {
        /// <summary>
        /// Equals to
        /// </summary>
        EQ = 0,

        /// <summary>
        /// Greater or equal to
        /// </summary>
        GTE = 1,

        /// <summary>
        /// Greater than
        /// </summary>
        GT = 2,

        /// <summary>
        /// Less or equals to
        /// </summary>
        LTE = 3,

        /// <summary>
        /// Less than
        /// </summary>
        LT = 4,
    }
}

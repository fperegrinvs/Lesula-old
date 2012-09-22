// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mapper.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Maps input key/value pairs to a set of intermediate key/value pairs.
//   Maps are the individual tasks which transform input records into a intermediate records.
//   The transformed intermediate records need not be of the same type as the input records.
//   A given input pair may map to zero or many output pairs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Contracts.Base
{
    /// <summary>
    /// Maps input key/value pairs to a set of intermediate key/value pairs.
    /// Maps are the individual tasks which transform input records into a intermediate records.
    /// The transformed intermediate records need not be of the same type as the input records. 
    /// A given input pair may map to zero or many output pairs.
    /// </summary>
    public abstract class Mapper
    {
        /// <summary>
        /// Maps a single input key/value pair into an intermediate key/value pair
        /// </summary>
        /// <param name="input">input key/pair</param>
        /// <returns>intermediate key/value pair</returns>
        public abstract JobData Map(JobData input);
    }
}

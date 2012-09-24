// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReducerRunner.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the ReducerRunner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Reducers
{
    using System.Collections.Generic;

    using Lesula.Client.Contracts.Base;
    using Lesula.Client.Contracts.Models;

    public abstract class ReducerRunner
    {
        protected JobOptions Options { get; set; }

        public void Execute()
        {
            var reducer = this.GetReducer();
            IList<IList<JobData>> input;
            do
            {
                input = this.LoadData();
                var output = new List<IList<JobData>>(input.Count);
                foreach (var record in input)
                {
                    output.Add(reducer.Reduce(record));
                    this.UpDateStatus();
                }

                this.ProcessData();
            }
            while (input.Count > 0);

            this.Cleanup();
        }

        public abstract IList<IList<JobData>> LoadData();

        public abstract void WriteData(IList<JobData> reducedData);

        public abstract Reducer GetReducer();

        public abstract void ProcessData();

        public abstract void UpDateStatus();

        public abstract void Cleanup();

        public abstract void Configure(JobOptions options);
    }
}

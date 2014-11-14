// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRunner.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the MapRunner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Mappers
{
    using System.Collections.Generic;

    using Lesula.Client.Contracts.Base;
    using Lesula.Client.Contracts.Models;

    public abstract class MapRunner
    {
        protected TransformationOptions Options { get; set; }

        public void Execute()
        {
            var mapper = this.GetMapper();
            IList<JobData> input;
            do
            {
                input = this.LoadData();
                var output = new List<JobData>(input.Count);
                foreach (var record in input)
                {
                    output.AddRange(mapper.Map(record));
                    this.UpDateStatus();
                }

                this.ProcessData();
            }
            while (input.Count > 0);

            this.Cleanup();
        }

        public abstract IList<JobData> LoadData();

        public abstract void WriteData(IList<JobData> mappedData);

        public abstract Mapper GetMapper();

        public abstract void ProcessData();

        public abstract void UpDateStatus();

        public abstract void Cleanup();

        public abstract void Configure(TransformationOptions options);
    }
}

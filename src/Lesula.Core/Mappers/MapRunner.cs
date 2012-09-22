namespace Lesula.Core
{
    using System.Collections.Generic;

    using Lesula.Core.Base;
    using Lesula.JobContracts;

    public abstract class MapRunner
    {
        protected MapperOptions Options { get; set; }

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
                    output.Add(mapper.Map(record));
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

        public abstract void Configure(MapperOptions options);
    }
}

namespace Lesula.Core
{
    using System.Collections.Generic;

    using Lesula.Core.Base;
    using Lesula.JobContracts;

    public abstract class ReducerRunner
    {
        protected MapperOptions Options { get; set; }

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

        public abstract void Configure(ReducerOptions options);
    }
}

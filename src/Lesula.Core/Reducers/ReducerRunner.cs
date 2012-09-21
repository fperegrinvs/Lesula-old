namespace Lesula.Core
{
    using System.Collections.Generic;

    using Lesula.JobContracts;

    public abstract class ReducerRunner<IK, I, OK, O>
        where I : IList<JobData<IK>>
        where O : IList<JobData<OK>>
    {
        protected MapperOptions Options { get; set; }

        public void Execute()
        {
            var reducer = this.GetReducer();
            IList<I> input;
            do
            {
                input = this.LoadData();
                var output = new List<O>(input.Count);
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

        public abstract IList<I> LoadData();

        public abstract void WriteData(IList<O> reducedData);

        public abstract Reducer<IK, I, OK, O> GetReducer();

        public abstract void ProcessData();

        public abstract void UpDateStatus();

        public abstract void Cleanup();

        public abstract void Configure(ReducerOptions options);
    }
}

namespace Lesula.Core
{
    using System.Collections.Generic;

    using Lesula.JobContracts;

    public abstract class MapRunner<IK, I, OK, O>
        where I : JobData<IK>
        where O : JobData<OK>
    {
        protected MapperOptions Options { get; set; }

        public void Execute()
        {
            var mapper = this.GetMapper();
            IList<I> input;
            do
            {
                input = this.LoadData();
                var output = new List<O>(input.Count);
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

        public abstract IList<I> LoadData();

        public abstract void WriteData(IList<O> mappedData);

        public abstract Mapper<IK, I, OK, O> GetMapper();

        public abstract void ProcessData();

        public abstract void UpDateStatus();

        public abstract void Cleanup();

        public abstract void Configure(MapperOptions options);
    }
}

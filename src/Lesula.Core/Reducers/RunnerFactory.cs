using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesula.Core.Reducers
{
    using Lesula.JobContracts;

    public class RunnerFactory
    {
        public ReducerRunner<IK, I, OK, O> CreateReduceRunner<IK, I, OK, O>(string reducerType)
            where I : IList<JobData<IK>>
            where O : IList<JobData<OK>>
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesula.Core.Mappers
{
    using Lesula.JobContracts;

    public class MapperFactory
    {
        public MapRunner<IK, I, OK, O> CreateMapRunner<IK, I, OK, O>(string mapperType)
            where I : JobData<IK>
            where O : JobData<OK>
        {
            throw new NotImplementedException();
        }
    }
}

using Lesula.Admin.Contracts;
using Lesula.Client.Contracts.Models;
using Lesula.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.Admin.Service
{
    public class DataUtils
    {
        public string SaveDataType(DataType collection)
        {
            var checker = new DataTypeChecker();
            var error = checker.CheckDataType(collection);
            if (!string.IsNullOrEmpty(error))
            {
                return  error;
            }

            return Context.Container.Resolve<IDataTypeDalc>().SaveDataType(collection);
        }

        public string SaveTransformation(DataTransformation collection)
        {
            var checker = new TransformationChecker();
            var error = checker.CheckTransformation(collection);
            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            return Context.Container.Resolve<ITransformationDalc>().SaveTransformation(collection);
        }
    }
}

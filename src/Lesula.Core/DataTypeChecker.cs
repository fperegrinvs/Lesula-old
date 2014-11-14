using Lesula.Client.Contracts.Base;
using Lesula.Client.Contracts.Models;
using Lesula.CodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.Core
{
    public class DataTypeChecker
    {
        public string CheckDataType(DataType dataType)
        {
            Assembly assembly = null;
            var error = TryCompile(dataType, out assembly);

            if (string.IsNullOrEmpty(error))
            {
                JobData jobdata = null;
                error = TryCreateInstance(assembly, dataType.Name, out jobdata);

                if (string.IsNullOrEmpty(error))
                {
                    string serialized = null;
                    error = TrySerialize(jobdata, out serialized);

                    if (string.IsNullOrEmpty(error))
                    {
                        JobData deserialized = null;
                        error = TryDeserialize(serialized, out deserialized);
                    }
                }
            }

            return error;
        }

        internal string TryCompile(DataType dataType, out Assembly assembly)
        {
            var contracts = Assembly.Load("Lesula.Client.Contracts");
            var core = Assembly.Load("Lesula.Core");
            var cassandra = Assembly.Load("Lesula.Cassandra");


            var errors = new List<string>();

            // see if code compiles
            assembly = Context.Container.Resolve<IAssemblyGenerator>().CreateAssembly(
                "Test",
                new List<string> { dataType.Code },
                new List<string> { "mscorlib", "System", "System.Core", contracts.Location, core.Location, cassandra.Location },
                out errors);

            if (errors != null && errors.Count != 0)
            {
                return string.Join("<br/>", errors);
            }
            else
            {
                // check if type exists
                if (assembly.ExportedTypes.FirstOrDefault(t => t.Name == dataType.Name) == null)
                {
                    return "Type '" + dataType.Name + "' not found in compiled code";
                }
            }

            return "";
        }

        /// <summary>
        /// Try to create a jobdata instance from a compiled assembly
        /// </summary>
        /// <param name="assembly">assembly that contains the jobdata derived class</param>
        /// <param name="typeName">the typename of the class to instantiate</param>
        /// <param name="data">the instanciated class</param>
        /// <returns>error messages if any</returns>
        internal string TryCreateInstance(Assembly assembly, string typeName, out JobData data)
        {
            data = (JobData)assembly.CreateInstance(typeName);

            if (data == null)
            {
                return "Unable to create a JobData instance";
            }

            //var properties = data.GetType().GetProperties(BindingFlags.Public);

            return "";
        }

        internal string TrySerialize(JobData data, out string serialized)
        {
            serialized = "";
            return "";
            //throw new NotImplementedException();
        }

        internal string TryDeserialize(string serialized, out JobData data)
        {
            data = null;
            return "";
            //throw new NotImplementedException();
        }

    }
}

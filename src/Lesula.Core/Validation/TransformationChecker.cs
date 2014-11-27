using Lesula.Admin.Contracts;
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
    public class TransformationChecker
    {
        public string CheckTransformation(DataTransformation transformation)
        {
            Assembly assembly = null;

            if (transformation.SourceTypeId == default(Guid))
            {
                return "Source type not defined";
            }

            var error = TryCompile(transformation, out assembly);

            if (string.IsNullOrEmpty(error))
            {
                error = transformation.TransformationType == Client.Contracts.Enumerators.TransformationType.Mapper
                ? TryInstanciate<Mapper>(assembly, transformation)
                : TryInstanciate<Reducer>(assembly, transformation);
            }

            return error;
        }

        internal string TryInstanciate<T>(Assembly assembly, DataTransformation transformation) where T : class
        {
            T returnObject = null;
            var error = TryCreateInstance(assembly, transformation.Name, out returnObject);

            if (string.IsNullOrEmpty(error))
            {
                string serialized = null;
                error = TrySerialize(returnObject, out serialized);

                if (string.IsNullOrEmpty(error))
                {
                    JobData deserialized = null;
                    error = TryDeserialize(serialized, out deserialized);
                }
            }

            return error;
        }

        internal string TryCompile(DataTransformation transformation, out Assembly assembly)
        {
            //check if datatypes exists
            var source = Context.Container.Resolve<IDataTypeDalc>().GetDataType(transformation.SourceTypeId);
            var target = transformation.TargetTypeId.HasValue ? Context.Container.Resolve<IDataTypeDalc>().GetDataType(transformation.TargetTypeId.Value) : null;

            if (source == null)
            {
                assembly = null;
                return "Source data type not found";
            }

            if (target == null && transformation.TargetTypeId.HasValue)
            {
                assembly = null;
                return "Target data type not found";
            }

            var contracts = Assembly.Load("Lesula.Client.Contracts");
            var core = Assembly.Load("Lesula.Core");
            var cassandra = Assembly.Load("Lesula.Cassandra");

            var files = new List<string>() { transformation.Code };

            if (source != null)
            {
                files.Add(source.Code);
            }

            if (target != null)
            {
                files.Add(target.Code);
            }

            var errors = new List<string>();

            // see if code compiles
            assembly = Context.Container.Resolve<IAssemblyGenerator>().CreateAssembly(
                "Test",
                files,
                new List<string> { "mscorlib", "System", "System.Core", contracts.Location, core.Location, cassandra.Location },
                out errors);

            if (errors != null && errors.Count != 0)
            {
                return string.Join("<br/>", errors);
            }
            else
            {
                // check if type exists
                if (assembly.ExportedTypes.FirstOrDefault(t => t.Name == transformation.Name) == null)
                {
                    return "Transformation '" + transformation.Name + "' not found in compiled code";
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
        internal string TryCreateInstance<T>(Assembly assembly, string typeName, out T data) where T : class
        {
            data = (T)assembly.CreateInstance(typeName);

            if (data == null)
            {
                return "Unable to create a Mapper instance";
            }

            //var properties = data.GetType().GetProperties(BindingFlags.Public);

            return "";
        }

        internal string TrySerialize<T>(T data, out string serialized) where T : class
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

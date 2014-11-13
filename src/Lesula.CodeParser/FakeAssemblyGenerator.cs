using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.CodeParser
{
    public class FakeAssemblyGenerator : IAssemblyGenerator
    {
        /// <summary>
        /// Assembly to fake
        /// </summary>
        public Assembly FakeAssembly { get; set;}

        /// <summary>
        /// Errors to show
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Create an assembly from strings
        /// </summary>
        /// <param name="assemblyName">assembly name</param>
        /// <param name="files">files text</param>
        /// <param name="references">full name of referred assemblies</param>
        /// <param name="errors">compilation errors</param>
        /// <returns>Compiled assembly</returns>
        public Assembly CreateAssembly(string assemblyName, List<string> files, List<string> references, out List<string> errors)
        {
            errors = Errors;
            return FakeAssembly ?? Assembly.GetCallingAssembly();
        }
    }
}

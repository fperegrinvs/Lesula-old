// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyGenerator.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//    http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   The assembly generator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.CodeParser
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;

    /// <summary>
    /// The assembly generator.
    /// </summary>
    public class AssemblyGenerator
    {
        /// <summary>
        /// Create an assembly from strings
        /// </summary>
        /// <param name="assemblyName">assembly name</param>
        /// <param name="files">files text</param>
        /// <param name="references">full name of referred assemblies</param>
        /// <param name="errors">compilation errors</param>
        /// <returns>Compiled assembly</returns>
        public static Assembly CreateAssembly(string assemblyName, List<string> files, List<string> references, out List<string> errors)
        {
            var trees = files.Select(file => SyntaxTree.ParseText(file)).ToList();
            var refs = references.Select(r => r.Contains(":") ? MetadataFileProvider.Default.GetReference(r) : MetadataReference.CreateAssemblyReference(r)).ToList();

            var compilation = Compilation.Create(
                assemblyName,
                syntaxTrees: trees,
                references: refs,
                options: new CompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var stream = new MemoryStream();
            var result = compilation.Emit(stream);

            if (result.Success)
            {
                errors = null;
                return Assembly.Load(stream.ToArray());
            }

            errors = result.Diagnostics.Select(alert => alert.Info.ToString()).ToList();
            return null;
        }
    }
}

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
            var refs = references.Select(MetadataReference.CreateAssemblyReference).ToList();

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

            errors = new List<string>();
            foreach (var alert in result.Diagnostics)
            {
                errors.Add(alert.Info.ToString());
            }

            return null;
        }

    }
}

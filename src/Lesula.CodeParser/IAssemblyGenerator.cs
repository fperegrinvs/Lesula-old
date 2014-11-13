using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.CodeParser
{
    public interface IAssemblyGenerator
    {
        Assembly CreateAssembly(string assemblyName, List<string> files, List<string> references, out List<string> errors);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.Client.Contracts.Enumerators
{
    /// <summary>
    /// The target type.
    /// </summary>
    public enum TargetKind
    {
        /// <summary>
        /// Source from cassandra
        /// </summary>
        Cassandra = 1,

        /// <summary>
        /// Source from Job
        /// </summary>
        Job = 2,
    }
}

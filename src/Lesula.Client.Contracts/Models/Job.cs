using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.Client.Contracts.Models
{
    /// <summary>
    /// Job
    /// </summary>
    public class Job
    {
        public Guid Id { get; set; }

        public DataSource Source { get; set; }

        public DataTransformation Transformation { get; set; }

        public DataTarget Target { get; set; }
    }
}

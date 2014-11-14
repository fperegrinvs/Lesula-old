using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.Client.Contracts.Models
{
    public class JobCollection
    {
        public Guid Id { get; set; }

        public string Alias { get; set; }

        public List<Job> JobList { get; set; }
    }
}

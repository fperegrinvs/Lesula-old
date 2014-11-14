using Lesula.JobContracts.Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesula.Client.Contracts.Implementation
{
    public class Column : IColumn
    {
        public byte[] Name { get; set; }

        public byte[] Value { get; set; }
    }
}

using System.Collections.Generic;

namespace Lesula.JobContracts.Cassandra
{
    public interface IRow
    {
        byte[] RowKey { get; set; }

        IList<IColumn> Columns { get; set; } 
    }
}

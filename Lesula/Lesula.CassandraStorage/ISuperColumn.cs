namespace Lesula.JobContracts.Cassandra
{
    using System.Collections.Generic;

    public interface ISuperColumn
    {
        byte[] Name { get; set; }

        IList<IColumn> Columns { get; set; }
    }
}

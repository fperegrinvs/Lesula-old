namespace Lesula.JobContracts.Cassandra
{
    using System.Collections.Generic;

    public interface IColumnSlice
    {
        byte[] StartColumn { get; set; }

        byte[] EndColumn { get; set; }

        IList<byte[]> ColumnNames { get; set; }

        int Count { get; set; }

        bool Reverse { get; set; }
    }
}

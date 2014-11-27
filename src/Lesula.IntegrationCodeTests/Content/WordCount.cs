using System;
using Lesula.Cassandra;
using Lesula.Cassandra.FrontEnd;
using System.Collections.Generic;
using Lesula.JobContracts.Cassandra;
using Lesula.Client.Contracts.Base;
using Lesula.Client.Contracts.Implementation;

/// <summary>
/// Word from a book
/// </summary>
public class WordCount : JobData
{

    public string Id { get; set; }

    public long Count { get; set; }

    /// <summary>
    /// Gets the element unique key
    /// </summary>
    public override byte[] Key
    {
        get
        {
            return Id.ToBytes();
        }
    }

    /// <summary>
    /// Convert object to a set of cassandra columns
    /// </summary>
    /// <returns>Conversion result</returns>
    public override IRow ToRow()
    {
        var row = new Row();
        row.RowKey = Key;
        row.Columns = new List<IColumn>();
        row.Columns.Add(new Column { Name = "Count".ToBytes(), Value = Count.ToBytesBigEndian() });
        return row;
    }

    /// <summary>
    /// Convert a set of cassandra columns to an instance of MyDataType
    /// </summary>
    /// <param name="row">Source data</param>
    /// <returns>Conversion result</returns>
    public override JobData FromRow(IRow row)
    {
        var word = new WordCount();

        word.Id = row.RowKey.ToUtf8String();

        foreach (var column in row.Columns)
        {
            var name = column.Name.ToUtf8String();
            switch (name)
            {
                case "Count":
                    word.Count = column.Value.ToInt64();
                    break;
            }
        }

        return word;
    }
}

using System;
using Lesula.Cassandra;
using Lesula.Cassandra.FrontEnd;
using System.Collections.Generic;
using Lesula.JobContracts.Cassandra;
using Lesula.Client.Contracts.Base;
using Lesula.Client.Contracts.Implementation;

/// <summary>
/// Book
/// </summary>
public class Book : JobData
{
    public string Title { get; set; }

    public string Body { get; set; }

    /// <summary>
    /// Gets the element unique key
    /// </summary>
    public override byte[] Key
    {
        get
        {
            return Title.ToBytes();
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
        row.Columns.Add(new Column { Name = "Title".ToBytes(), Value = Title.ToBytes() });
        row.Columns.Add(new Column { Name = "Body".ToBytes(), Value = Body.ToBytes() });
        return row;
    }

    /// <summary>
    /// Convert a set of cassandra columns to an instance of MyDataType
    /// </summary>
    /// <param name="row">Source data</param>
    /// <returns>Conversion result</returns>
    public override JobData FromRow(IRow row)
    {
        var book = new Book();

        foreach (var column in row.Columns)
        {
            var name = column.Name.ToUtf8String();
            switch (name)
            {
                case "Title":
                    book.Title = column.Value.ToUtf8String();
                    break;
                case "Body":
                    book.Body = column.Value.ToUtf8String();
                    break;
            }
        }

        return book;
    }
}

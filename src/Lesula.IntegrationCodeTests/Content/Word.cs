using System;
using Lesula.Client.Contracts.Base;
using Lesula.Client.Contracts.Implementation;

/// <summary>
/// Word from a book
/// </summary>
public class Word : JobData
{

    public string Word { get; set; }

    /// <summary>
    /// Gets the element unique key
    /// </summary>
    public override byte[] Key
    {
        get
        {
            return Word.ToBytes();
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
        row.Columns.Add(new Column { Name = "Word".ToBytes(), Value = Word.ToBytes() });
        return row;
    }

    /// <summary>
    /// Convert a set of cassandra columns to an instance of MyDataType
    /// </summary>
    /// <param name="row">Source data</param>
    /// <returns>Conversion result</returns>
    public override JobData FromRow(IRow row)
    {
        var word = new Word();

        foreach (var column in row.Columns)
        {
            var name = column.Name.ToUtf8String();
            switch (name)
            {
                case "Word":
                    word.Word = column.Value.ToUtf8String();
                    break;
            }
        }

        return word;
    }
}

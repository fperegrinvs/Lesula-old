using Lesula.Client.Contracts.Base;
using System.Collections.Generic;
using System.Linq;

public class WordReducer : Reducer
{
    /// <summary>
    /// Reduces a set of intermediate values which share a key to a smaller set of values.
    /// </summary>
    /// <param name="input">input data</param>
    /// <returns>reduced data</returns>
    public override IList<JobData> Reduce(IList<JobData> input)
    {
        var result = new WordCount() { Id = ((Word)input[0]).Data, Count = input.Count };

        return new List<JobData>() { result };
    }
}

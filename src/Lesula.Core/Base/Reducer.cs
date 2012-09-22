namespace Lesula.Core.Base
{
    using System.Collections.Generic;

    /// <summary>
    /// 1 - Shuffle  
    /// Reducer is input the grouped output of a Mapper. In the phase the framework, for each Reducer,
    /// fetches the relevant partition of the output of all the Mappers, via HTTP.
    /// 2 - Sort  The framework groups Reducer inputs by keys (since different Mappers may have output the same key)
    /// in this stage.  The shuffle and sort phases occur simultaneously i.e. while outputs are being fetched they are merged.
    /// 3 - Reduce  Reduces a set of intermediate values which share a key to a smaller set of values.
    /// </summary>
    public abstract class Reducer
    {
        /// <summary>
        /// Reduces a set of intermediate values which share a key to a smaller set of values.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract IList<JobData> Reduce(IList<JobData> input);
    }
}

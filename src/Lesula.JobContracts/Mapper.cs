namespace Lesula.JobContracts
{
    /// <summary>
    /// Maps input key/value pairs to a set of intermediate key/value pairs.
    /// Maps are the individual tasks which transform input records into a intermediate records.
    /// The transformed intermediate records need not be of the same type as the input records. 
    /// A given input pair may map to zero or many output pairs.
    /// </summary>
    /// <typeparam name="IK">input key Type</typeparam>
    /// <typeparam name="I">input type</typeparam>
    /// <typeparam name="OK">output key type</typeparam>
    /// <typeparam name="O">output type</typeparam>
    public abstract class Mapper<IK, I, OK, O>
        where I : JobData<IK>
        where O : JobData<OK>
    {
        /// <summary>
        /// Maps a single input key/value pair into an intermediate key/value pair
        /// </summary>
        /// <param name="input">input key/pair</param>
        /// <returns>intermediate key/value pair</returns>
        public abstract O Map(I input);
    }
}

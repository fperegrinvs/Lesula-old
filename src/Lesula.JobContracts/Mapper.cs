namespace Lesula.JobContracts
{
    /// <summary>
    /// Maps input key/value pairs to a set of intermediate key/value pairs.
    /// Maps are the individual tasks which transform input records into a intermediate records.
    /// The transformed intermediate records need not be of the same type as the input records. 
    /// A given input pair may map to zero or many output pairs.
    /// </summary>
    public abstract class Mapper
    {
        /// <summary>
        /// Maps a single input key/value pair into an intermediate key/value pair
        /// </summary>
        /// <param name="input">input key/pair</param>
        /// <returns>intermediate key/value pair</returns>
        public abstract JobData Map(JobData input);
    }
}

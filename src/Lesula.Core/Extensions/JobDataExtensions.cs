namespace Lesula.Core.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Lesula.JobContracts;
    using Lesula.JobContracts.Cassandra;

    public static class JobDataExtensions
    {
        public static IList<IRow> ToRows(this IList<JobData> data)
        {
            var rows = new List<IRow>(data.Count);
            rows.AddRange(data.Select(element => element.ToRow()));
            return rows;
        }
    }
}

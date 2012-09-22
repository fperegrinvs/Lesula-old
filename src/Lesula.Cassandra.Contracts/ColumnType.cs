using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesula.CassandraStorage
{
    public enum ColumnType
    {
        Column = 1,
        SuperColumn = 2,
        CounterColumn = 3,
        SuperCounterColumn = 4
    }
}

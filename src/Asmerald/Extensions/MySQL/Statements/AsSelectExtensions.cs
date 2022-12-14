using System;
using System.Collections.Generic;
using System.Linq;
using Asmerald.Columns;
using Asmerald.Expressions;
using Asmerald.QueryBuilders;
using Asmerald.Statements;
using Asmerald.Statements.MySQL;

namespace Asmerald.MySQL
{
    public static partial class AsmeraldAsSelectExtensions
    {
        public static WithAsSelectStatement<T> AsSelect<T>(this RecursiveStatement<T> stmt, IQueryBuilder subQuery)
            where T : ITable, new()
        {
            return new WithAsSelectStatement<T>(stmt.QueryBuilder, subQuery);
        }
        public static WithAsSelectStatement<T> AsSelect<T>(this WithTableStatement<T> stmt, IQueryBuilder subQuery)
            where T : ITable, new()
        {
            return new WithAsSelectStatement<T>(stmt.QueryBuilder, subQuery);
        }
    }
}

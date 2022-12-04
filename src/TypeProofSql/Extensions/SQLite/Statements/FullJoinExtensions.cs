using System;
using System.Collections.Generic;
using System.Linq;
using TypeProofSql.Columns;
using TypeProofSql.Expressions;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Statements;
using TypeProofSql.Statements.SQLite;

namespace TypeProofSql.SQLite
{
    public static partial class TypeProofSqlFullJoinExtensions
    {
        public static FullOuterJoinStatement<T, J> FullJoin<T, J>(this SelectFromStatement<T> stmt)
            where T : ITable, new()
            where J : ITable, new()
        {
            return new FullOuterJoinStatement<T, J>(stmt.QueryBuilder);
        }
        public static UpdateConditionalJoinStatement<T, J> FullJoin<T, J>(this UpdateFromStatement<T> stmt)
            where T : ITable, new()
            where J : ITable, new()
        {
            return new UpdateConditionalJoinStatement<T, J>(stmt.QueryBuilder);
        }
        public static UpdateConditionalJoinStatement<T, J> FullJoin<T, J>(this UpdateFromSubQueryStatement<T> stmt)
            where T : ITable, new()
            where J : ITable, new()
        {
            return new UpdateConditionalJoinStatement<T, J>(stmt.QueryBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;
using TypeProofSql.Statements;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;
using TypeProofSql.Statements;

namespace TypeProofSql.Statements.SQLite
{
    public class NonConditionalJoinStatement<T1, T2> : NonConditionalJoinStatement
        where T1 : ITable, new()
        where T2 : ITable, new()
    {
        public NonConditionalJoinStatement(IQueryBuilder queryBuilder)
            : base(queryBuilder, new T1(), new T2())
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;
using TypeProofSql.Statements;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Statements.SQLite
{
    public class OnStatement<T, J> : OnStatement
        where T : ITable, new()
        where J : ITable, new()
    {
        public OnStatement(IQueryBuilder queryBuilder, ISelectColumn<T> left, ISelectColumn<J> right)
            : base(queryBuilder, left, right)
        {
        }
    }
}

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
    public class UpdateIgnore<T>Statement : UpdateAbortStatement
        where T : ITable, new()
    {
        public UpdateIgnore(IQueryBuilder queryBuilder)
            : base(queryBuilder, new T())
        {
        }
    }
}
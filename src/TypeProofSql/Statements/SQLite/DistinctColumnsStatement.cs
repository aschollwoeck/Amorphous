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
    public class DistinctColumnsStatement : IStatement
    {
        public IQueryBuilder QueryBuilder { get; private set; }
        public List<ISelectColumn> Columns { get; private set; } = new List<ISelectColumn>();
        public DistinctColumnsStatement(IQueryBuilder queryBuilder, IEnumerable<ISelectColumn> columns)
        {
            this.QueryBuilder = queryBuilder;
            this.QueryBuilder.AddStatment(this);
            this.Columns.AddRange(columns);
        }
    }
}
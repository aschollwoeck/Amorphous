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
    public class JoinStatement : IStatement
    {
        public IQueryBuilder QueryBuilder { get; private set; }
        public ITable Left { get; private set; }
        public ITable Right { get; private set; }
        public JoinStatement(IQueryBuilder queryBuilder, ITable left, ITable right)
        {
            this.QueryBuilder = queryBuilder;
            this.QueryBuilder.AddStatment(this);
            this.Left = left;
            this.Right = right;
        }
    }
}
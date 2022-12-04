using System.Collections.Generic;
using TypeProofSql.Columns;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Statements.SQLite
{
    public class CompoundStatement : IStatement
    {
        public IQueryBuilder QueryBuilder { get; private set; }
        public IQueryBuilder SubQueryBuilder { get; private set; }
        public CompoundStatement() { }
        public CompoundStatement(IQueryBuilder queryBuilder, IQueryBuilder subQueryBuilder)
        {
            this.QueryBuilder = queryBuilder;
            this.QueryBuilder.AddStatment(this);
            this.SubQueryBuilder = subQueryBuilder;
        }
    }
}

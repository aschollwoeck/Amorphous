using System.Collections.Generic;
using TypeProofSql.Columns;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Statements.SQLite
{
    public class SelectFromSubQueryStatement<T> : FromSubQueryStatement<T>
        where T : ITable, new()
    {
        public SelectFromSubQueryStatement() { }
        public SelectFromSubQueryStatement(IQueryBuilder queryBuilder, IQueryBuilder subQueryBuilder)
            : base(queryBuilder, subQueryBuilder)
        {
        }
    }
}

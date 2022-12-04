using System.Collections.Generic;
using TypeProofSql.Columns;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Statements.SQLite
{
    public class ReturningSelectStatement<T> : SelectColumnsStatement
        where T : ITable, new()
    {
        public ReturningSelectStatement() { }
        public ReturningSelectStatement(IQueryBuilder queryBuilder, IEnumerable<ISelectColumn<T>> columns)
            : base(queryBuilder, columns)
        {
        }
    }
}

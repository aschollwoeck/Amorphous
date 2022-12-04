using System.Collections.Generic;
using TypeProofSql.Columns;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Statements.SQLite
{
    public class ConditionalJoinStatement<T, J> : JoinStatement<T, J>
        where T : ITable, new()
        where J : ITable, new()
    {
        public ConditionalJoinStatement() { }
        public ConditionalJoinStatement(IQueryBuilder queryBuilder)
            : base(queryBuilder, new T(), new J())
        {
        }
    }
}

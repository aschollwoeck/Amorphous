using System.Collections.Generic;
using Asmerald.Columns;
using Asmerald.QueryBuilders;
using Asmerald.Expressions;

namespace Asmerald.Statements.Oracle
{
    public class DistinctColumnsStatement : IStatement
    {
        public IQueryBuilder QueryBuilder { get; private set; }
        public List<ISelectExpression> Columns { get; private set; } = new List<ISelectExpression>();
        public DistinctColumnsStatement() { }
        public DistinctColumnsStatement(IQueryBuilder queryBuilder, IEnumerable<ISelectExpression> columns)
        {
            this.QueryBuilder = queryBuilder;
            this.QueryBuilder.AddStatment(this);
            this.Columns.AddRange(columns);
        }
    }
}

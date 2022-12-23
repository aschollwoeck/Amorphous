using System.Collections.Generic;
using Asmerald.Columns;
using Asmerald.QueryBuilders;
using Asmerald.Expressions;

namespace Asmerald.Statements.MariaDB
{
    public class UpdateReplaceStatement : ReplaceStatement
    {
        public ITable Table { get; private set; }
        public UpdateReplaceStatement() { }
        public UpdateReplaceStatement(IQueryBuilder queryBuilder, ITable table)
            : base(queryBuilder)
        {
            this.Table = table;
        }
    }
}
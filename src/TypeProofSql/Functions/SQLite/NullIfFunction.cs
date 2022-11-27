using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;
using TypeProofSql.Statements;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Functions.SQLite
{
    public class NullIfFunction : ISelectExpression
    {
        public ISelectExpression X { get; private set; }
        public ISelectExpression Y { get; private set; }
        public NullIfFunction() { }
        public NullIfFunction(ISelectExpression x, ISelectExpression y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

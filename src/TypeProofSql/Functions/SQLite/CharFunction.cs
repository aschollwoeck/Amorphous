using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;
using TypeProofSql.Statements;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Functions.SQLite
{
    public class CharFunction : ISelectExpression
    {
        public ISelectExpression X1 { get; private set; }
        public ISelectExpression X2 { get; private set; }
        public List<ISelectExpression> Xn { get; private set; } = new List<ISelectExpression>();
        public CharFunction() { }
        public CharFunction(ISelectExpression x1, ISelectExpression x2, IEnumerable<ISelectExpression> xn)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Xn.AddRange(xn);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;
using TypeProofSql.Statements;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Functions.SQLite
{
    public class TimeFunctionExpression : ISelectExpression
    {
        public IExpression Value { get; private set; }
        public List<String> Modifier { get; private set; } = new List<String>();
        public TimeFunctionExpression() { }
        public TimeFunctionExpression(IExpression value, IEnumerable<String> modifier
        )
        {
            this.Value = value;
            this.Modifier.AddRange(modifier);
        }
    }
}

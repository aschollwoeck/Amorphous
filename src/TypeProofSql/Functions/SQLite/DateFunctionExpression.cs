using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;
using TypeProofSql.Statements;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Expressions;

namespace TypeProofSql.Functions.SQLite
{
    public class DateFunctionExpression : ISelectExpression
    {
        public IExpression Value { get; private set; }
        public List<String> Modifier { get; private set; } = new List<String>();
        public DateFunctionExpression() { }
        public DateFunctionExpression(IExpression value, IEnumerable<String> modifier
        )
        {
            this.Value = value;
            this.Modifier.AddRange(modifier);
        }
    }
}
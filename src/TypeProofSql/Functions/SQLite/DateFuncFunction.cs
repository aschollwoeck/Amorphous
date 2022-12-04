using System;
using System.Collections.Generic;
using TypeProofSql.Expressions;

namespace TypeProofSql.Functions.SQLite
{
    public class DateFuncFunction : IFunction
    {
        public ISelectExpression Value { get; private set; }
        public List<String> Modifier { get; private set; } = new List<String>();
        public DateFuncFunction() { }
        public DateFuncFunction(ISelectExpression value, IEnumerable<String> modifier)
        {
            this.Value = value;
            this.Modifier.AddRange(modifier);
        }
    }
}

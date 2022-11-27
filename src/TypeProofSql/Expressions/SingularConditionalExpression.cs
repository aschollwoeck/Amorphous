﻿using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;

namespace TypeProofSql.Expressions
{
    public class SingularConditionalExpression : ConditionalExpression
    {
        public SingularConditionalExpression(ISelectExpression column, object value) : base(column, value)
        {

        }
    }
}

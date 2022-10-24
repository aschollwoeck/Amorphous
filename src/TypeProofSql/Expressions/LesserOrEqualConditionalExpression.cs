﻿using System;
using System.Collections.Generic;
using System.Text;
using TypeProofSql.Columns;

namespace TypeProofSql.Expressions
{
    public class LesserOrEqualConditionalExpression : SingularConditionalExpression
    {
        public LesserOrEqualConditionalExpression(IColumn column, object value) : base(column, value)
        {

        }
    }
}
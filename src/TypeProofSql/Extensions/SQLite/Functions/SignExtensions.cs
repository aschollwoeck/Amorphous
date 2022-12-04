using System;
using System.Collections.Generic;
using System.Linq;
using TypeProofSql.Columns;
using TypeProofSql.Expressions;
using TypeProofSql.Functions.SQLite;
using TypeProofSql.Statements;

namespace TypeProofSql.SQLite
{
    public static partial class TypeProofSqlSignExtensions
    {
        public static SignFunction Sign(this SQLiteDSLContext stmt, ISelectExpression x)
        {
            return new SignFunction(x);
        }
        public static SignFunction Sign(this Int16 x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Int32 x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Int64 x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this UInt16 x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this UInt32 x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this UInt64 x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Decimal x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Double x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this String x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Char x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Boolean x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Byte x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this DateTime x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this Single x)
        {
            return new SignFunction(x.Expr());
        }
        public static SignFunction Sign(this ISelectColumn x)
        {
            return new SignFunction(x);
        }
    }
}

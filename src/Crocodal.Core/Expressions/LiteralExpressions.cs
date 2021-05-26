using System;

namespace Crocodal.Core.Expressions
{
    public interface ILiteralExpression : ISqlExpression
    {
    }

    public class IntLiteralExpression : ILiteralExpression
    {
        public int Value { get; set; }

        public IntLiteralExpression(int value)
        {
            Value = value;
        }
    }

    public class DoubleLiteralExpression : ILiteralExpression
    {
        public double Value { get; set; }

        public DoubleLiteralExpression(double value)
        {
            Value = value;
        }
    }

    public class DecimalLiteralExpression : ILiteralExpression
    {
        public decimal Value { get; set; }

        public DecimalLiteralExpression(decimal value)
        {
            Value = value;
        }
    }

    public class DateLiteralExpression : ILiteralExpression
    {
        public DateTime Value { get; }

        public DateLiteralExpression(DateTime value)
        {
            Value = value;
        }
    }

    public class StringLiteralExpression : ILiteralExpression
    {
        public string Value { get; }
        public bool IsUnicode { get; }

        public StringLiteralExpression(string value, bool isUnicode)
        {
            Value = value;
            IsUnicode = isUnicode;
        }
    }
}

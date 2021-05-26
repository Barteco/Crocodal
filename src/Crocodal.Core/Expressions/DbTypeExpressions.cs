namespace Crocodal.Core.Expressions
{
    public interface IDbTypeExpression : ISqlExpression
    {
    }

    public class IntDbTypeExpression : IDbTypeExpression
    {
    }

    public class DoubleDbTypeExpression : IDbTypeExpression
    {
    }

    public class DecimalDbTypeExpression : IDbTypeExpression
    {
        public int Precision { get; }
        public int Scale { get; }

        public DecimalDbTypeExpression(int precision, int scale)
        {
            Precision = precision;
            Scale = scale;
        }
    }

    public class StringDbTypeExpression : IDbTypeExpression
    {
        public bool IsUnicode { get; }
        public int? MaxLength { get; }

        public StringDbTypeExpression(bool isUnicode, int? maxLength)
        {
            IsUnicode = isUnicode;
            MaxLength = maxLength;
        }
    }

    public class DateDbTypeExpression : IDbTypeExpression
    {
    }

    public class CustomDbTypeExpression : IDbTypeExpression
    {
        public string OverridenType { get; }

        public CustomDbTypeExpression(string type)
        {
            OverridenType = type;
        }
    }
}

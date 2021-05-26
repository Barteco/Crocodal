using Operator = System.Linq.Expressions.ExpressionType;

namespace Crocodal.Core.Expressions
{
    public class BinaryExpression : ISqlExpression
    {
        public ISqlExpression Left { get; }
        public ISqlExpression Right { get; }
        public Operator Operator { get; }

        public BinaryExpression(ISqlExpression left, ISqlExpression right, Operator @operator)
        {
            Left = left;
            Right = right;
            Operator = @operator;
        }
    }
}

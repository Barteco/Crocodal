using Operator = System.Linq.Expressions.ExpressionType;

namespace Crocodal.Core.Expressions
{
    public class UnaryExpression : ISqlExpression
    {
        public ISqlExpression Operand { get; }
        public Operator Operator { get; }

        public UnaryExpression(ISqlExpression operand, Operator @operator)
        {
            Operand = operand;
            Operator = @operator;
        }
    }
}

using Operator = System.Linq.Expressions.ExpressionType;

namespace Crocodal.Core.Expressions
{
    public class BinaryAssignmentExpression : BinaryExpression
    {
        public new Operator Operator { get; }

        public BinaryAssignmentExpression(ISqlExpression left, ISqlExpression right) : base(left, right, Operator.Assign)
        {
        }
    }
}

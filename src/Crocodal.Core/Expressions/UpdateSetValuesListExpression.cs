namespace Crocodal.Core.Expressions
{
    public class UpdateSetValuesListExpression : ISqlExpression
    {
        public BinaryAssignmentExpression[] Children { get; }

        public UpdateSetValuesListExpression(params BinaryAssignmentExpression[] children)
        {
            Children = children;
        }
    }
}

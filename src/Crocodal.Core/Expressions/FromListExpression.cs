namespace Crocodal.Core.Expressions
{
    public class FromListExpression : ISqlExpression
    {
        public IFromExpression[] Children { get; }

        public FromListExpression(params IFromExpression[] children)
        {
            Children = children;
        }
    }
}

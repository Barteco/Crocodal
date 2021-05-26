namespace Crocodal.Core.Expressions
{
    public class ListExpression : ISqlExpression
    {
        public ISqlExpression[] Children { get; }

        public ListExpression(params ISqlExpression[] children)
        {
            Children = children;
        }
    }
}

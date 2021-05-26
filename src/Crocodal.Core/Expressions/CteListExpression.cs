namespace Crocodal.Core.Expressions
{
    public class CteListExpression : ISqlExpression
    {
        public CteExpression[] Children { get; }

        public CteListExpression(params CteExpression[] children)
        {
            Children = children;
        }
    }
}

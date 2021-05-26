namespace Crocodal.Core.Expressions
{
    public class UnionExpression : IQueryExpression
    {
        public IQueryExpression Left { get; }
        public IQueryExpression Right { get; }

        public UnionExpression(IQueryExpression left, IQueryExpression right)
        {
            Left = left;
            Right = right;
        }
    }
}

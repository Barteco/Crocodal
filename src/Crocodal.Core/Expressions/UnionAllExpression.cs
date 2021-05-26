namespace Crocodal.Core.Expressions
{
    public class UnionAllExpression : IQueryExpression
    {
        public IQueryExpression Left { get; }
        public IQueryExpression Right { get; }

        public UnionAllExpression(IQueryExpression left, IQueryExpression right)
        {
            Left = left;
            Right = right;
        }
    }
}

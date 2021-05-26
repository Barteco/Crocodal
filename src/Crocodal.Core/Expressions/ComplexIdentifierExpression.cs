namespace Crocodal.Core.Expressions
{
    public class ComplexIdentifierExpression : ITableIdentifierExpression, IIdentifierExpression
    {
        public IIdentifierExpression Left { get; }
        public IdentifierExpression Right { get; }

        public ComplexIdentifierExpression(IIdentifierExpression left, IdentifierExpression right)
        {
            Left = left;
            Right = right;
        }
    }
}

namespace Crocodal.Core.Expressions
{
    public class AliasExpression : ISqlExpression
    {
        public ISqlExpression Expression { get; }
        public IdentifierExpression Alias { get; }

        public AliasExpression(ISqlExpression expression, IdentifierExpression alias)
        {
            Expression = expression;
            Alias = alias;
        }
    }
}

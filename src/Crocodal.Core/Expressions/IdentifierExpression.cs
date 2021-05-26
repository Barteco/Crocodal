namespace Crocodal.Core.Expressions
{
    public class IdentifierExpression : ITableIdentifierExpression, IIdentifierExpression
    {
        public string Name { get; }

        public IdentifierExpression(string name)
        {
            Name = name;
        }
    }
}

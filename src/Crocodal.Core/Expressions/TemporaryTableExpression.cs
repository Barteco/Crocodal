namespace Crocodal.Core.Expressions
{
    public class TemporaryTableExpression : ITableIdentifierExpression
    {
        public string Name { get; }

        public TemporaryTableExpression(string name)
        {
            Name = name;
        }
    }
}

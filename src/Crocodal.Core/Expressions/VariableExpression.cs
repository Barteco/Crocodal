namespace Crocodal.Core.Expressions
{
    public class VariableExpression : ISqlExpression
    {
        public string Name { get; }

        public VariableExpression(string name)
        {
            Name = name;
        }
    }
}

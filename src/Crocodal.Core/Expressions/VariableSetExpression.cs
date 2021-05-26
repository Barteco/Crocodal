namespace Crocodal.Core.Expressions
{
    public class VariableSetExpression : ISqlExpression
    {
        public VariableExpression Variable { get; }

        public VariableSetExpression(VariableExpression variable)
        {
            Variable = variable;
        }
    }
}

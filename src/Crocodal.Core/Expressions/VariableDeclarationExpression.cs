namespace Crocodal.Core.Expressions
{
    public class VariableDeclarationExpression : ISqlExpression
    {
        public VariableExpression Variable { get; }
        public IDbTypeExpression Type { get; }

        public VariableDeclarationExpression(VariableExpression variable, IDbTypeExpression type)
        {
            Variable = variable;
            Type = type;
        }
    }
}

namespace Crocodal.Core.Expressions
{
    public class FunctionCallExpression : ISqlExpression
    {
        public IIdentifierExpression Function { get; }
        public ListExpression Parameters { get; }

        public FunctionCallExpression(IIdentifierExpression function, ListExpression parameters)
        {
            Function = function;
            Parameters = parameters;
        }
    }
}

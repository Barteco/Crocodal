namespace Crocodal.Core.Expressions
{
    public class ExecuteStoredProcedureExpression : ISqlExpression
    {
        public IIdentifierExpression Procedure { get; }
        public ListExpression Parameters { get; }

        public ExecuteStoredProcedureExpression(IIdentifierExpression procedure, ListExpression parameters)
        {
            Procedure = procedure;
            Parameters = parameters;
        }
    }
}

namespace Crocodal.Statements
{
    public class ExecuteStoredProcedureStatement<TResult> : AbstractStatement<TResult>, IStoredProcedureStatement<TResult>
    {
        public ExecuteStoredProcedureStatement(IDatabase database) : base(database)
        {
        }
    }
}

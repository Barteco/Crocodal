namespace Crocodal.Statements
{
    public class CallFunctionStatement<TResult> : AbstractStatement<TResult>
    {
        public CallFunctionStatement(IDatabase database) : base(database)
        {
        }
    }
}

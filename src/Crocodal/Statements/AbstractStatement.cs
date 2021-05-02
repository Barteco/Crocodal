namespace Crocodal.Statements
{
    public abstract class AbstractStatement<TResult> : IExecutableStatement<TResult>
    {
        public IDatabase Database { get; }

        protected AbstractStatement(IDatabase database)
        {
            Database = database;
        }
    }
}

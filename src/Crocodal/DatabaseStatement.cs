namespace Crocodal
{
    public abstract class DatabaseStatement<TResult> : IExecutableStatement<TResult>
    {
        internal IDatabase Database { get; }

        protected DatabaseStatement(IDatabase database)
        {
            Database = database;
        }
    }
}
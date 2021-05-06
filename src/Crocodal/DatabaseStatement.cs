namespace Crocodal
{
    public class DatabaseStatement<TResult> : IExecutableStatement<TResult>
    {
        public IDatabase Database { get; }

        protected DatabaseStatement(IDatabase database)
        {
            Database = database;
        }

        public virtual IExecutableStatement<TResult> Unwrap()
        {
            return this;
        }
    }
}
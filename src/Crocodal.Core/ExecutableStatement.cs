namespace Crocodal.Core
{
    public abstract class ExecutableStatement<TResult> : ExecutableStatement, IExecutable<TResult>
    {
        public IDatabase Database { get; }

        protected ExecutableStatement(IDatabase database)
        {
            Database = database;
        }
    }

    public abstract class ExecutableStatement : IExecutable
    {
    }
}
using Crocodal.Internal.Statements;

namespace Crocodal
{
    public class StoredProcedure<TResult> : IExecutableStatement<TResult>, IWrappedStatement<TResult>
    {
        public IDatabase Database { get; }
        public IExecutableStatement<TResult> Statement { get; }

        public StoredProcedure(IDatabase database, string name, object paramters)
        {
            Database = database;
            Statement = new ExecuteStoredProcedureStatement<TResult>(database, name, paramters);
        }
    }
}

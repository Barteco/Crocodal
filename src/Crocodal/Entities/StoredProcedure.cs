using Crocodal.Core.Statements;
using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Entities
{
    public class StoredProcedure<TResult> : IStoredProcedure<TResult>, ISourcable, IUnwrappable
    {
        private readonly ExecuteStoredProcedureStatement<TResult> _statement;
        private readonly IDatabase _database;

        public StoredProcedure(IDatabase database, string name, object paramters)
        {
            _statement = new ExecuteStoredProcedureStatement<TResult>(database, name, paramters);
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => _statement;
    }
}
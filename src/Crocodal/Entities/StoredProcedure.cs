using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Entities
{
    public class StoredProcedure<TResult> : IStoredProcedure<TResult>, ISourcable, IUnwrappable
    {
        private readonly IDatabase _database;

        public StoredProcedure(IDatabase database, string name, object paramters)
        {
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => throw new System.NotImplementedException();
    }
}
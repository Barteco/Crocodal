using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Builders
{
    internal class InsertBuilder<TSource> : IInsertBuilder<TSource>, ISourcable, IUnwrappable
    {
        private readonly IDatabase _database;

        public InsertBuilder(IDatabase database)
        {
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => throw new System.NotImplementedException();
    }
}
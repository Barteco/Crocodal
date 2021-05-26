using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Builders
{
    internal class DeleteBuilder<TSource> : IDeleteBuilder<TSource>, ISourcable, IUnwrappable
    {
        private readonly IDatabase _database;

        public DeleteBuilder(IDatabase database)
        {
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => throw new System.NotImplementedException();
    }
}
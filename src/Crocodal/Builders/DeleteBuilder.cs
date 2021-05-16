using Crocodal.Core.Statements;
using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Builders
{
    internal class DeleteBuilder<TSource> : IDeleteBuilder<TSource>, ISourcable, IUnwrappable
    {
        private readonly DeleteStatement _statement;
        private readonly IDatabase _database;

        public DeleteBuilder(IDatabase database)
        {
            _statement = new DeleteStatement(database);
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => _statement;
    }
}
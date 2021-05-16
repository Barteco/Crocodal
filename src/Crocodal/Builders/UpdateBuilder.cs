using Crocodal.Core.Statements;
using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Builders
{
    internal class UpdateBuilder<TSource> : IUpdateBuilder<TSource>, ISourcable, IUnwrappable
    {
        private readonly UpdateStatement _statement;
        private readonly IDatabase _database;

        public UpdateBuilder(IDatabase database)
        {
            _statement = new UpdateStatement(database);
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => _statement;
    }
}
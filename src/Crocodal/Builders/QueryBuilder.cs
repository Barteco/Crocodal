using Crocodal.Core.Statements;
using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;
using System;

namespace Crocodal.Builders
{
    internal class QueryBuilder<TSource> : IQueryBuilder<TSource>, ISourcable, IUnwrappable
    {
        private readonly QueryStatement<TSource> _statement;
        private readonly IDatabase _database;

        public QueryBuilder(IDatabase database, Action<QueryOptionsBuilder> options)
        {
            _statement = new QueryStatement<TSource>(database);
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => _statement;
    }
}
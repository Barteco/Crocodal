using System;

namespace Crocodal.Builders
{
    internal class QueryBuilder<TSource> : IQueryBuilder<TSource>, IBuilder
    {
        public IDatabase Database { get; }

        public QueryBuilder(IDatabase database, Action<QueryOptionsBuilder> options)
        {
            Database = database;
        }

        public ISqlExpression Build() => throw new System.NotImplementedException();
    }
}
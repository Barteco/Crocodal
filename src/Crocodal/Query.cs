using Crocodal.Internal.Core;

namespace Crocodal
{
    public abstract class Query<TDatabase, TEntity>
        where TDatabase : IDatabase
    {
        public Query(TDatabase database)
        {
            var builder = new QueryBuilder(database);
            builder.From<TEntity>();
        }
    }
}
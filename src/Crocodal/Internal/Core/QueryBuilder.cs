namespace Crocodal.Internal.Core
{
    internal class QueryBuilder : IBuilder
    {
        private readonly IDatabase _database;

        public QueryBuilder(IDatabase database)
        {
            _database = database;
        }

        public IBuilder From<TEntity>()
        {
            return this;
        }

        public IBuilder Where<TEntity>()
        {
            return this;
        }
    }
}

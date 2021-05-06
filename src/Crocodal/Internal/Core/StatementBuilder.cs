namespace Crocodal.Internal.Core
{
    internal class QueryBuilder : IStatementBuilder
    {
        private readonly IDatabase _database;

        public QueryBuilder(IDatabase database)
        {
            _database = database;
        }

        public IStatementBuilder From<TEntity>()
        {
            return this;
        }

        public IStatementBuilder Where<TEntity>()
        {
            return this;
        }
    }
}

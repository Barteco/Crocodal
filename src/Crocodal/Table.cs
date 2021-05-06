using Crocodal.Internal.Core;

namespace Crocodal
{
    public class Table<TEntity> : ITableStatement<TEntity>
    {
        public IStatementBuilder Builder { get; }

        public Table(IDatabase database)
        {
            Builder = new QueryBuilder(database);
            Builder.From<TEntity>();
        }
    }
}
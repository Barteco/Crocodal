using Crocodal.Internal.Core;

namespace Crocodal
{
    public class View<TEntity> : IViewStatement<TEntity>
    {
        public IStatementBuilder Builder { get; }

        public View(IDatabase database)
        {
            Builder = new QueryBuilder(database);
            Builder.From<TEntity>();
        }
    }
}

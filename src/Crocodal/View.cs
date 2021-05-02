using Crocodal.Statements;

namespace Crocodal
{
    public class View<TEntity> : QueryStatement<TEntity>, IViewStatement<TEntity>
    {
        public View(IDatabase database) : base(database)
        {
        }
    }
}

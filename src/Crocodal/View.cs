namespace Crocodal
{
    public class View<TEntity> : IQueryStatement<TEntity>, IViewStatement<TEntity>
    {
        public IDatabase Database { get; }
    }
}

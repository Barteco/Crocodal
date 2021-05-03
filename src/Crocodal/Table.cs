namespace Crocodal
{
    public class Table<TEntity> : IQueryStatement<TEntity>, ITableStatement<TEntity>
    {
        public IDatabase Database { get; }
    }
}
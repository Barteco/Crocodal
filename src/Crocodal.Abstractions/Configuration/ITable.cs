namespace Crocodal
{
    public interface ITable<TEntity>
    {
        void Configure(ITableBuilder<TEntity> builder);
    }
}
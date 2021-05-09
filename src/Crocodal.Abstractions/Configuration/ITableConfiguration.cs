namespace Crocodal
{
    public interface ITableConfiguration<TEntity>
    {
        void Configure(ITableBuilder<TEntity> builder);
    }
}
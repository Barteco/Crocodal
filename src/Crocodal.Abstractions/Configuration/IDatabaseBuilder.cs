namespace Crocodal
{
    public interface IDatabaseBuilder
    {
        void Configure<TEntity>(ITable<TEntity> configuration);
        void Configure<TView>(IView<TView> configuration);
        void Configure(IProcedure configuration);
        void Configure(IFunction configuration);
    }
}
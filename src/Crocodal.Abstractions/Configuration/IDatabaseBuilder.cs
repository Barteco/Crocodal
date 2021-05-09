namespace Crocodal
{
    public interface IDatabaseBuilder
    {
        void Configure<TEntity>(ITableConfiguration<TEntity> configuration);
        void Configure<TView>(IViewConfiguration<TView> configuration);
        void Configure(IStoredProcedureConfiguration configuration);
        void Configure(IFunctionConfiguration configuration);
    }
}
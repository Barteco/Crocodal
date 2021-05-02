namespace Crocodal
{
    public interface IViewStatement<TEntity>
        : IWherableStatement<TEntity>,
        ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        IOrderableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }
}

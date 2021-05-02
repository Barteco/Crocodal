namespace Crocodal
{
    public interface ITableStatement<TEntity>
        : IJoinableStatement<TEntity>,
        IWherableStatement<TEntity>,
        IOrderableStatement<TEntity>,
        ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>,
        IInsertableStatement<TEntity>,
        IUpdatableStatement<TEntity>,
        IDeletableStatement<TEntity>
    {
    }
}

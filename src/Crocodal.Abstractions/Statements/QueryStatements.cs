namespace Crocodal
{
    public interface IQueryStatement<TResult>
        : IExecutableStatement<TResult>
    {
    }

    public interface IQueryableStatement<TEntity>
    {
    }

    public interface ISelectableStatement<TEntity>
        : IQueryableStatement<TEntity>
    {
    }

    public interface ITakeableStatement<TEntity>
        : ISelectableStatement<TEntity>
    {
    }

    public interface ISkippableStatement<TEntity>
        : ITakeableStatement<TEntity>
    {
    }

    public interface IOrderableStatement<TEntity>
        : ISkippableStatement<TEntity>
    {
    }

    public interface IWherableViewStatement<TEntity>
        : IOrderableStatement<TEntity>
    {
    }

    public interface IWherableTableStatement<TEntity>
        : IOrderableStatement<TEntity>,
        IBatchUpdatableStatement<TEntity>,
        IBatchDeletableStatement<TEntity>
    {
    }

    public interface IJoinableViewStatement<TEntity>
        : IWherableViewStatement<TEntity>
    {
    }

    public interface IJoinableTableStatement<TEntity>
        : IWherableTableStatement<TEntity>
    {
    }
}
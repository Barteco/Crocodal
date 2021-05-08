namespace Crocodal
{
    public interface IQueryStatement<TResult>
        : IExecutableStatement<TResult>
    {
    }

    public interface IQueryableStatement<TEntity>
        : IBuildableStatement
    {
    }

    public interface ISelectableStatement<TEntity>
        : IQueryableStatement<TEntity>
    {
    }

    public interface ITakeableStatement<TEntity>
        : ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }

    public interface ISkippableStatement<TEntity>
        : ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }

    public interface IOrderableStatement<TEntity>
        : ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }

    public interface IWherableStatement<TEntity>
        : IOrderableStatement<TEntity>,
        ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>,
        IBatchUpdatableStatement<TEntity>,
        IBatchDeletableStatement<TEntity>
    {
    }

    public interface IWherableQueryStatement<TEntity>
        : IOrderableStatement<TEntity>,
        ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }

    public interface IJoinableStatement<TEntity>
        : IOrderableStatement<TEntity>,
        ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }

    public interface IJoinableQueryStatement<TEntity>
        : IWherableQueryStatement<TEntity>,
        IOrderableStatement<TEntity>,
        ISkippableStatement<TEntity>,
        ITakeableStatement<TEntity>,
        ISelectableStatement<TEntity>,
        IQueryableStatement<TEntity>
    {
    }
}
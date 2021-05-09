namespace Crocodal
{
    public interface IDeleteStatement 
        : IExecutableStatement<int>
    {
    }

    public interface IDeletableStatement<TEntity>
    {
    }

    public interface IBatchDeletableStatement<TEntity>
    {
    }
}

namespace Crocodal
{
    public interface IDeleteStatement : IExecutableStatement<int>
    {
    }

    public interface IDeletableStatement<TEntity> : IBuildableStatement
    {
    }

    public interface IBatchDeletableStatement<TEntity> : IBuildableStatement
    {
    }
}

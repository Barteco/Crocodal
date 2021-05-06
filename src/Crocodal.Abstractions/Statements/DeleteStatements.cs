namespace Crocodal
{
    public interface IDeleteStatement : IExecutableStatement<int>
    {
    }

    public interface IDeletableStatement<TEntity> : IBuildableStatement
    {
    }
}

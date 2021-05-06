namespace Crocodal
{
    public interface IUpdateStatement : IExecutableStatement<int>
    {
    }

    public interface IUpdatableStatement<TEntity> : IBuildableStatement
    {
    }
}

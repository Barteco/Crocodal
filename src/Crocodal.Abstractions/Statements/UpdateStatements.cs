namespace Crocodal
{
    public interface IUpdateStatement : IExecutableStatement<int>
    {
    }

    public interface IUpdatableStatement<TEntity>
    {
    }

    public interface IBatchUpdatableStatement<TEntity>
    {
    }
}

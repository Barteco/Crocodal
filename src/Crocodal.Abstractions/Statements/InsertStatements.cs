namespace Crocodal
{
    public interface IInsertStatement : IExecutableStatement<int>
    {
    }

    public interface IInsertableStatement<TEntity>
    {
    }
}

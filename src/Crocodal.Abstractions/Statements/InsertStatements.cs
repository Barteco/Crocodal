namespace Crocodal
{
    public interface IInsertStatement 
        : IExecutableStatement<int>
    {
    }

    public interface IInsertableStatement<TEntity>
    {
    }

    public interface IInsertableStatement<TDatabase, TEntity>
        where TDatabase : IDatabase
    {
    }
}

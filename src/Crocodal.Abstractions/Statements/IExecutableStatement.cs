namespace Crocodal
{
    public interface IExecutableStatement
    {
        public IDatabase Database { get; }
    }

    public interface IExecutableStatement<TEntity> : IExecutableStatement
    {
    }
}
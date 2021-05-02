namespace Crocodal
{
    public interface IExecutableStatement
    {
    }

    public interface IExecutableStatement<TEntity> : IExecutableStatement
    {
        public IDatabase Database { get; }
    }
}
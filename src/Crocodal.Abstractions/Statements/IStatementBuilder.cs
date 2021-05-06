namespace Crocodal
{
    public interface IStatementBuilder
    {
        public IStatementBuilder From<TEntity>();
        public IStatementBuilder Where<TEntity>();
    }
}

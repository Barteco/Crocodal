namespace Crocodal
{
    public interface IBuilder
    {
        public IBuilder From<TEntity>();
        public IBuilder Where<TEntity>();
    }
}

namespace Crocodal
{
    public interface IWrappedStatement<TResult>
    {
        public IExecutableStatement<TResult> Statement { get; }
    }
}
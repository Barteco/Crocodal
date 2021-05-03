namespace Crocodal.Internal.Statements
{
    internal class QueryStatement<TResult> : IQueryStatement<TResult>
    {
        public IDatabase Database { get; }
    }
}

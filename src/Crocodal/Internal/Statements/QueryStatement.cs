namespace Crocodal.Internal.Statements
{
    internal class QueryStatement<TResult> : DatabaseStatement<None>, IQueryStatement<TResult>
    {
        public QueryStatement(IDatabase database) : base(database)
        {
        }
    }
}

namespace Crocodal.Statements
{
    public class QueryStatement<TResult> : AbstractStatement<TResult>, IQueryStatement<TResult>
    {
        public QueryStatement(IDatabase database) : base(database)
        {
        }
    }
}

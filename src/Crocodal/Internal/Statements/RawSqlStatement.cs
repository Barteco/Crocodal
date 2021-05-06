namespace Crocodal.Internal.Statements
{
    internal class RawSqlStatement<TResult> : DatabaseStatement<TResult>
    {
        public string Sql { get; }
        public object Parameters { get; }

        public RawSqlStatement(Database database, string sql, object parameters) : base(database)
        {
            Sql = sql;
            Parameters = parameters;
        }
    }
}

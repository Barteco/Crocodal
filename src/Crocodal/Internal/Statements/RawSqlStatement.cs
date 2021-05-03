namespace Crocodal.Internal.Statements
{
    internal class RawSqlStatement<TResult> : IExecutableStatement<TResult>
    {
        public IDatabase Database { get; }
        public string Sql { get; }
        public object Parameters { get; }

        public RawSqlStatement(IDatabase database, string sql, object parameters)
        {
            Sql = sql;
            Parameters = parameters;
            Database = database;
        }
    }
}

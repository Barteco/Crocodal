using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class RawSqlStatement<TResult> : ExecutableStatement<TResult>
    {
        public string Sql { get; }
        public object Parameters { get; }

        public RawSqlStatement(IDatabase database, string sql, object parameters) : base(database)
        {
            Sql = sql;
            Parameters = parameters;
        }
    }
}

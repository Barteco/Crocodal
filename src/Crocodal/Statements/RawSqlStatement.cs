using System.Collections.Generic;

namespace Crocodal.Statements
{
    public class RawSqlStatement<TResult> : AbstractStatement<TResult>
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

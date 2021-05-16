using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class QueryStatement<TResult> : ExecutableStatement<None>
    {
        public WithStatement[] WithStatements { get; set; }

        public QueryStatement(IDatabase database) : base(database)
        {
        }
    }
}

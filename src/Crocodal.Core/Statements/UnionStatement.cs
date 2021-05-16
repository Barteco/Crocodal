using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class UnionStatement<TResult> : ExecutableStatement<None>
    {
        public QueryStatement<TResult> Left { get; set; }
        public QueryStatement<TResult> Right { get; set; }

        public UnionStatement(IDatabase database) : base(database)
        {
        }
    }
}

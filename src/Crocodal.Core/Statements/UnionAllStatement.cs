using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class UnionAllStatement<TResult> : ExecutableStatement<None>
    {
        public QueryStatement<TResult> Left { get; set; }
        public QueryStatement<TResult> Right { get; set; }

        public UnionAllStatement(IDatabase database) : base(database)
        {
        }
    }
}

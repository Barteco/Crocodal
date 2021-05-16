using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class InsertFromStatement<TSource> : ExecutableStatement<int>, IInsert
    {
        public InsertFromStatement(IDatabase database, IQuery<TSource> from) : base(database)
        {
        }
    }
}
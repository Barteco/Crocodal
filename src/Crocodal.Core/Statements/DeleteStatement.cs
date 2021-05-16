using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class DeleteStatement : ExecutableStatement<int>, IDelete
    {
        public DeleteStatement(IDatabase database) : base(database)
        {
        }

        public DeleteStatement(IDatabase database, params object[] entities) : base(database)
        {
        }
    }
}
using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class UpdateStatement : ExecutableStatement<int>, IUpdate
    {
        public UpdateStatement(IDatabase database) : base(database)
        {
        }

        public UpdateStatement(IDatabase database, params object[] entities) : base(database)
        {
        }
    }
}

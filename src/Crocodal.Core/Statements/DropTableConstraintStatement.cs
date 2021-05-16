using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class DropTableConstraintStatement : ExecutableStatement<None>
    {
        public DropTableConstraintStatement(IDatabase database) : base(database)
        {
        }
    }
}

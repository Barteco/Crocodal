using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class DropTableStatement : ExecutableStatement<None>
    {
        public DropTableStatement(IDatabase database) : base(database)
        {
        }
    }
}

using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class DropTableColumnStatement : ExecutableStatement<None>
    {
        public DropTableColumnStatement(IDatabase database) : base(database)
        {
        }
    }
}
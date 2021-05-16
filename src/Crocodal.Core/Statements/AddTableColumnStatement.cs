using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class AddTableColumnStatement : ExecutableStatement<None>
    {
        public AddTableColumnStatement(IDatabase database) : base(database)
        {
        }
    }
}
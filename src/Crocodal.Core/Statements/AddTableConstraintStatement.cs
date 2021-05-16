using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class AddTableConstraintStatement : ExecutableStatement<None>
    {
        public AddTableConstraintStatement(IDatabase database) : base(database)
        {
        }
    }
}
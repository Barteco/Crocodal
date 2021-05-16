using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class CreateOrAlterStoredProcedureStatement : ExecutableStatement<None>
    {
        public CreateOrAlterStoredProcedureStatement(IDatabase database) : base(database)
        {
        }
    }
}
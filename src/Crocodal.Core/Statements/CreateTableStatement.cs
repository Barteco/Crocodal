using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class CreateTableStatement : ExecutableStatement<None>
    {
        public CreateTableStatement(IDatabase database) : base(database)
        {
        }
    }
}
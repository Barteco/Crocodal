namespace Crocodal.Statements
{
    public class CreateOrAlterStoredProcedureStatement : AbstractStatement<None>
    {
        public CreateOrAlterStoredProcedureStatement(IDatabase database) : base(database)
        {
        }
    }
}

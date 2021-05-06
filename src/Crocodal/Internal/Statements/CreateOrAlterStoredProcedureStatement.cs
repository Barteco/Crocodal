namespace Crocodal.Internal.Statements
{
    internal class CreateOrAlterStoredProcedureStatement : DatabaseStatement<None>
    {
        public CreateOrAlterStoredProcedureStatement(IDatabase database) : base(database)
        {
        }
    }
}
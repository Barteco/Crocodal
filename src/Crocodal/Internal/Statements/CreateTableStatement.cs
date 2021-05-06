namespace Crocodal.Internal.Statements
{
    internal class CreateTableStatement : DatabaseStatement<None>
    {
        public CreateTableStatement(IDatabase database) : base(database)
        {
        }
    }
}
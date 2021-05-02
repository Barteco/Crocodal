namespace Crocodal.Statements
{
    public class CreateTableStatement : AbstractStatement<None>
    {
        public CreateTableStatement(IDatabase database) : base(database)
        {
        }
    }
}

namespace Crocodal.Statements
{
    public class AddTableColumnStatement : AbstractStatement<None>
    {
        public AddTableColumnStatement(IDatabase database) : base(database)
        {
        }
    }
}

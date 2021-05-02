namespace Crocodal.Statements
{
    public class DropTableColumnStatement : AbstractStatement<None>
    {
        public DropTableColumnStatement(IDatabase database) : base(database)
        {
        }
    }
}

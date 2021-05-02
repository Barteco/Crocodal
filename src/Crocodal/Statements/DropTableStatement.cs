namespace Crocodal.Statements
{
    public class DropTableStatement : AbstractStatement<None>
    {
        public DropTableStatement(IDatabase database) : base(database)
        {
        }
    }
}

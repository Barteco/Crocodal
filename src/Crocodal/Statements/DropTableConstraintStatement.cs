namespace Crocodal.Statements
{
    public class DropTableConstraintStatement : AbstractStatement<None>
    {
        public DropTableConstraintStatement(IDatabase database) : base(database)
        {
        }
    }
}
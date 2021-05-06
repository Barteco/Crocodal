namespace Crocodal.Internal.Statements
{
    internal class DropTableConstraintStatement : DatabaseStatement<None>
    {
        public DropTableConstraintStatement(IDatabase database) : base(database)
        {
        }
    }
}

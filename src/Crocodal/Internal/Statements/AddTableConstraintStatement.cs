namespace Crocodal.Internal.Statements
{
    internal class AddTableConstraintStatement : DatabaseStatement<None>
    {
        public AddTableConstraintStatement(IDatabase database) : base(database)
        {
        }
    }
}
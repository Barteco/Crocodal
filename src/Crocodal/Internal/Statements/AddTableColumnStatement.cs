namespace Crocodal.Internal.Statements
{
    internal class AddTableColumnStatement : DatabaseStatement<None>
    {
        public AddTableColumnStatement(IDatabase database) : base(database)
        {
        }
    }
}
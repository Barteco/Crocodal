namespace Crocodal.Internal.Statements
{
    internal class DropTableColumnStatement : DatabaseStatement<None>
    {
        public DropTableColumnStatement(IDatabase database) : base(database)
        {
        }
    }
}
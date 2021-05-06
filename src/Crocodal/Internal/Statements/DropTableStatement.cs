namespace Crocodal.Internal.Statements
{
    internal class DropTableStatement : DatabaseStatement<None>
    {
        public DropTableStatement(IDatabase database) : base(database)
        {
        }
    }
}

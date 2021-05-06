namespace Crocodal.Internal.Statements
{
    internal class UpdateStatement : DatabaseStatement<None>, IUpdateStatement
    {
        public UpdateStatement(IDatabase database) : base(database)
        {
        }
    }
}

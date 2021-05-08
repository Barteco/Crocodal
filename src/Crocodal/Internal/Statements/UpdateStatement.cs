namespace Crocodal.Internal.Statements
{
    internal class UpdateStatement : DatabaseStatement<None>, IUpdateStatement
    {
        public UpdateStatement(IDatabase database) : base(database)
        {
        }

        public UpdateStatement(IDatabase database, params object[] entities) : base(database)
        {
        }
    }
}

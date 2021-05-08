namespace Crocodal.Internal.Statements
{
    internal class DeleteStatement : DatabaseStatement<None>, IDeleteStatement
    {
        public DeleteStatement(IDatabase database) : base(database)
        {
        }

        public DeleteStatement(IDatabase database, params object[] entities) : base(database)
        {
        }
    }
}
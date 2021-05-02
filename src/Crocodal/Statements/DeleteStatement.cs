namespace Crocodal.Statements
{
    public class DeleteStatement : AbstractStatement<int>, IDeleteStatement
    {
        public DeleteStatement(IDatabase database) : base(database)
        {
        }
    }
}

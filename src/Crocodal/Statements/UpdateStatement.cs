namespace Crocodal.Statements
{
    public class UpdateStatement : AbstractStatement<int>, IUpdateStatement
    {
        public UpdateStatement(IDatabase database) : base(database)
        {
        }
    }
}

namespace Crocodal.Statements
{
    public class InsertStatement : AbstractStatement<int>, IInsertStatement
    {
        public InsertStatement(IDatabase database) : base(database)
        {
        }
    }
}

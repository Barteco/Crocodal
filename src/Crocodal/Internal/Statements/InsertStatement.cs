namespace Crocodal.Internal.Statements
{
    internal class InsertStatement : DatabaseStatement<None>, IInsertStatement
    {
        public object[] Entities { get; }

        public InsertStatement(IDatabase database, params object[] entities) : base(database)
        {
            Entities = entities;
        }
    }
}
using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class InsertStatement : ExecutableStatement<int>, IInsert
    {
        public object[] Entities { get; }

        public InsertStatement(IDatabase database, params object[] entities) : base(database)
        {
            Entities = entities;
        }
    }
}
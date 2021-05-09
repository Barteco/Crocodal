using Crocodal.Internal.Statements;
using Crocodal.Internal.Unwrapping;

namespace Crocodal
{
    public class Insert : DatabaseStatement<int>, IUnwrappable
    {
        private readonly InsertStatement _statement;

        public Insert(Database database, object entity, params object[] entities) : base(database)
        {
            _statement = new InsertStatement(database, entity, entities);
        }

        IExecutableStatement IUnwrappable.Unwrap()
        {
            return _statement;
        }
    }
}
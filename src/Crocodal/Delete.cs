using Crocodal.Internal.Statements;
using Crocodal.Internal.Unwrapping;

namespace Crocodal
{
    public class Delete : DatabaseStatement<int>, IUnwrappable
    {
        private readonly DeleteStatement _statement;

        public Delete(Database database, object entity, params object[] entities) : base(database)
        {
            _statement = new DeleteStatement(database, entity, entities);
        }

        IExecutableStatement IUnwrappable.Unwrap()
        {
            return _statement;
        }
    }
}
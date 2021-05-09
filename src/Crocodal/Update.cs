using Crocodal.Internal.Statements;
using Crocodal.Internal.Unwrapping;
using System;

namespace Crocodal
{

    public class Update : DatabaseStatement<int>, IUnwrappable
    {
        private readonly UpdateStatement _statement;

        public Update(Database database, object entity, params object[] entities) : base(database)
        {
            _statement = new UpdateStatement(database, entity, entities);
        }

        IExecutableStatement IUnwrappable.Unwrap()
        {
            return _statement;
        }
    }
}
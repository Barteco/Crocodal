using Crocodal.Internal.Statements;
using Crocodal.Internal.Unwrapping;
using System;

namespace Crocodal
{
    public class StoredProcedure<TResult> : DatabaseStatement<TResult>, IUnwrappable
    {
        private readonly ExecuteStoredProcedureStatement<TResult> _statement;

        public StoredProcedure(Database database, string name, object paramters) : base(database)
        {
            _statement = new ExecuteStoredProcedureStatement<TResult>(database, name, paramters);
        }

        IExecutableStatement IUnwrappable.Unwrap()
        {
            return _statement;
        }

        public static implicit operator TResult(StoredProcedure<TResult> _)
        {
            throw new InvalidCastException("Implicit cast to stored procedure result cannot be used directly in code. It's intended only as a syntax enhancement for stored procedure generation. To call this procedure, use Execute()/ExecuteAsync() method");
        }
    }
}
using Crocodal.Internal.Statements;
using System;

namespace Crocodal
{
    public class StoredProcedure<TResult> : DatabaseStatement<TResult>
    {
        private readonly ExecuteStoredProcedureStatement<TResult> _statement;

        public StoredProcedure(Database database, string name, object paramters) : base(database)
        {
            _statement = new ExecuteStoredProcedureStatement<TResult>(database, name, paramters);
        }

        public override IExecutableStatement<TResult> Unwrap()
        {
            return _statement;
        }

        public static implicit operator TResult(StoredProcedure<TResult> _)
        {
            throw new InvalidCastException("Implicit cast to stored procedure result cannot be used directly in code. It's intended only as a syntax enhancement for stored procedure generation. To call this procedure, use Execute()/ExecuteAsync() method");
        }
    }
}
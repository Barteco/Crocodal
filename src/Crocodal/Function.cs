using Crocodal.Internal.Statements;
using Crocodal.Internal.Unwrapping;
using System;

namespace Crocodal
{
    public class Function<TResult> : DatabaseStatement<TResult>, IUnwrappable
    {
        private readonly CallFunctionStatement<TResult> _statement;

        public Function(Database database, string name, object paramters) : base(database)
        {
            _statement = new CallFunctionStatement<TResult>(database, name, paramters);
        }

        IExecutableStatement IUnwrappable.Unwrap()
        {
            return _statement;
        }

        public static implicit operator TResult(Function<TResult> _)
        {
            throw new InvalidCastException("Implicit cast to user-defined function result cannot be used directly in code. It's intended only as a syntax enhancement for stored procedure generation. To call this function, use Execute()/ExecuteAsync() method");
        }
    }
}
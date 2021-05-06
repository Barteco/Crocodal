using Crocodal.Internal.Statements;
using System;

namespace Crocodal
{
    public class Function<TResult> : DatabaseStatement<TResult>
    {
        private readonly CallFunctionStatement<TResult> _statement;

        public Function(Database database, string name, object paramters) : base(database)
        {
            _statement = new CallFunctionStatement<TResult>(database, name, paramters);
        }

        public override IExecutableStatement<TResult> Unwrap()
        {
            return _statement;
        }

        public static implicit operator TResult(Function<TResult> _)
        {
            throw new InvalidCastException("Implicit cast to user-defined function result cannot be used directly in code. It's intended only as a syntax enhancement for stored procedure generation. To call this function, use Execute()/ExecuteAsync() method");
        }
    }
}
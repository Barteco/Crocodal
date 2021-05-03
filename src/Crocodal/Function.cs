using Crocodal.Internal.Statements;
using System;

namespace Crocodal
{
    public class Function<TResult> : IExecutableStatement<TResult>, IWrappedStatement<TResult>
    {
        public IDatabase Database { get; }
        public IExecutableStatement<TResult> Statement { get; }

        public Function(IDatabase database, string name, object paramters)
        {
            Database = database;
            Statement = new CallFunctionStatement<TResult>(database, name, paramters);
        }

        public static implicit operator TResult(Function<TResult> self)
        {
            throw new InvalidCastException("Implicit cast to user-defined function cannot be used directly in code. It's intended only as a syntax enhancement for stored procedure generation. To call this function, use Execute()/ExecuteAsync() method");
        }
    }
}
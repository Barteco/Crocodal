using Crocodal.Statements;
using System;

namespace Crocodal
{
    public class Function<TResult> : CallFunctionStatement<TResult>, IFunctionStatement<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public Function(IDatabase database, string name, object paramters) : base(database)
        {
            Name = name;
            Paramters = paramters;
        }

        public static implicit operator TResult(Function<TResult> self)
        {
            throw new InvalidCastException("Implicit cast to user-defined function cannot be used directly in code. It's intended only as a syntax enhancement for stored procedure generation. To call this function, use Execute()/ExecuteAsync() method");
        }
    }
}
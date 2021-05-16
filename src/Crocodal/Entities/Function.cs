using Crocodal.Core.Statements;
using Crocodal.Internal.Sourcing;
using Crocodal.Internal.Unwrapping;

namespace Crocodal.Entities
{
    public class Function<TResult> : IFunction<TResult>, ISourcable, IUnwrappable
    {
        private readonly CallFunctionStatement<TResult> _statement;
        private readonly IDatabase _database;

        public Function(IDatabase database, string name, object paramters)
        {
            _statement = new CallFunctionStatement<TResult>(database, name, paramters);
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;

        IExecutable IUnwrappable.Unwrap() => _statement;
    }
}
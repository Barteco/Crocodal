using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class CallFunctionStatement<TResult> : ExecutableStatement<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public CallFunctionStatement(IDatabase database, string name, object paramters) : base(database)
        {
            Name = name;
            Paramters = paramters;
        }
    }
}

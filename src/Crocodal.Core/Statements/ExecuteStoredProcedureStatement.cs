using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class ExecuteStoredProcedureStatement<TResult> : ExecutableStatement<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public ExecuteStoredProcedureStatement(IDatabase database, string name, object paramters) : base(database)
        {
            Name = name;
            Paramters = paramters;
        }
    }
}

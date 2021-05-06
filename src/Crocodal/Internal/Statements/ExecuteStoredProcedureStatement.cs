namespace Crocodal.Internal.Statements
{
    internal class ExecuteStoredProcedureStatement<TResult> : DatabaseStatement<TResult>, IStoredProcedureStatement<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public ExecuteStoredProcedureStatement(Database database, string name, object paramters) : base(database)
        {
            Name = name;
            Paramters = paramters;
        }
    }
}

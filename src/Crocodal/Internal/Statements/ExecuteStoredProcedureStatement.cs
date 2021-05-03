namespace Crocodal.Internal.Statements
{
    internal class ExecuteStoredProcedureStatement<TResult> : IStoredProcedureStatement<TResult>
    {
        public IDatabase Database { get; }
        public string Name { get; }
        public object Paramters { get; }

        public ExecuteStoredProcedureStatement(IDatabase database, string name, object paramters)
        {
            Database = database;
            Name = name;
            Paramters = paramters;
        }
    }
}

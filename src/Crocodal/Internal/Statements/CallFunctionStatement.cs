namespace Crocodal.Internal.Statements
{
    internal class CallFunctionStatement<TResult> : IFunctionStatement<TResult>
    {
        public IDatabase Database { get; }
        public string Name { get; }
        public object Paramters { get; }

        public CallFunctionStatement(IDatabase database, string name, object paramters)
        {
            Database = database;
            Name = name;
            Paramters = paramters;
        }
    }
}

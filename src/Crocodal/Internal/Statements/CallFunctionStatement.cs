namespace Crocodal.Internal.Statements
{
    internal class CallFunctionStatement<TResult> : DatabaseStatement<TResult>, IFunctionStatement<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public CallFunctionStatement(Database database, string name, object paramters) : base(database)
        {
            Name = name;
            Paramters = paramters;
        }
    }
}

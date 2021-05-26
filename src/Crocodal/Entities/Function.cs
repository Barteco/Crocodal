namespace Crocodal.Entities
{
    public class Function<TResult> : IFunction<TResult>, IBuilder
    {
        public IDatabase Database { get; }

        public Function(IDatabase database, string name, object paramters)
        {
            Database = database;
        }

        public ISqlExpression Build() => throw new System.NotImplementedException();
    }
}
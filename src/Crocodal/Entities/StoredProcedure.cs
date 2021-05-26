namespace Crocodal.Entities
{
    public class StoredProcedure<TResult> : IStoredProcedure<TResult>, IBuilder
    {
        public IDatabase Database { get; }

        public StoredProcedure(IDatabase database, string name, object paramters)
        {
            Database = database;
        }

        public ISqlExpression Build() => throw new System.NotImplementedException();
    }
}
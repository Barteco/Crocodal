namespace Crocodal.Builders
{
    internal class InsertBuilder<TSource> : IInsertBuilder<TSource>, IBuilder
    {
        public IDatabase Database { get; }

        public InsertBuilder(IDatabase database)
        {
            Database = database;
        }

        public ISqlExpression Build() => throw new System.NotImplementedException();
    }
}
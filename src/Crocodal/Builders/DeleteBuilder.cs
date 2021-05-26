namespace Crocodal.Builders
{
    internal class DeleteBuilder<TSource> : IDeleteBuilder<TSource>, IBuilder
    {
        public IDatabase Database { get; }

        public DeleteBuilder(IDatabase database)
        {
            Database = database;
        }

        public ISqlExpression Build() => throw new System.NotImplementedException();
    }
}
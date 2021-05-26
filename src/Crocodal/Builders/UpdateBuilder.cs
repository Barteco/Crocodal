namespace Crocodal.Builders
{
    internal class UpdateBuilder<TSource> : IUpdateBuilder<TSource>, IBuilder
    {
        public IDatabase Database { get; }

        public UpdateBuilder(IDatabase database)
        {
            Database = database;
        }

        public ISqlExpression Build() => throw new System.NotImplementedException();
    }
}
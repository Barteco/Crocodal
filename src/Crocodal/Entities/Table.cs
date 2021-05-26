namespace Crocodal.Entities
{
    public class Table<TSource> : ITable<TSource>
    {
        public IDatabase Database { get; }

        public Table(IDatabase database)
        {
            Database = database;
        }
    }
}
namespace Crocodal.Entities
{
    public class View<TSource> : IView<TSource>
    {
        public IDatabase Database { get; }

        public View(IDatabase database)
        {
            Database = database;
        }
    }
}
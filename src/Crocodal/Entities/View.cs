using Crocodal.Internal.Sourcing;

namespace Crocodal.Entities
{
    public class View<TSource> : IView<TSource>, ISourcable
    {
        private readonly IDatabase _database;
        IDatabase ISourcable.GetDatabase() => _database;

        public View(IDatabase database)
        {
            _database = database;
        }
    }
}
using Crocodal.Internal.Sourcing;

namespace Crocodal.Entities
{
    public class Table<TSource> : ITable<TSource>, ISourcable
    {
        private readonly IDatabase _database;

        public Table(IDatabase database)
        {
            _database = database;
        }

        IDatabase ISourcable.GetDatabase() => _database;
    }
}
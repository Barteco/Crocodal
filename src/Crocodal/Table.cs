using Crocodal.Statements;

namespace Crocodal
{
    public class Table<TEntity> : QueryStatement<TEntity>, ITableStatement<TEntity>
    {
        public Table(IDatabase database) : base(database)
        {
        }
    }
}

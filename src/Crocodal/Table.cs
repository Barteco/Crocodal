namespace Crocodal
{
    public class Table<TDatabase, TEntity> : Query<TDatabase, TEntity>,
        IJoinableTableStatement<TEntity>,
        IInsertableStatement<TEntity>,
        IInsertableStatement<TDatabase, TEntity>,
        IUpdatableStatement<TEntity>,
        IDeletableStatement<TEntity>
        where TDatabase : IDatabase
    {
        public Table(TDatabase database) : base(database)
        {
        }
    }
}
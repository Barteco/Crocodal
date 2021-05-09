namespace Crocodal
{
    public class View<TDatabase, TEntity> : Query<TDatabase, TEntity>,
        IJoinableViewStatement<TEntity>
        where TDatabase : IDatabase
    {
        public View(TDatabase database) : base(database)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crocodal
{
    public static class StatementExtensions
    {
        #region Query statement methods

        public static IQueryStatement<List<TEntity>> Query<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            throw new NotImplementedException();
        }

        public static IQueryStatement<TEntity> QuerySingle<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            throw new NotImplementedException();
        }

        public static IQueryStatement<int> Count<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            throw new NotImplementedException();
        }

        public static IQueryStatement<bool> Exists<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Insert statement methods

        public static IInsertStatement Insert<TEntity>(this IInsertableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public static IInsertStatement Insert<TDatabase, TEntity>(this IInsertableStatement<TDatabase, TEntity> statement, Expression<Func<TDatabase, IQueryStatement<TEntity>>> expression) where TDatabase : IDatabase
        {
            throw new NotImplementedException();
        }

        public static IInsertStatement Insert<TDatabase, TEntity>(this IInsertableStatement<TDatabase, TEntity> statement, Expression<Func<TDatabase, IQueryStatement<List<TEntity>>>> expression) where TDatabase : IDatabase
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update statement methods

        public static IUpdateStatement Update<TEntity>(this IBatchUpdatableStatement<TEntity> statement, Expression<Func<TEntity, TEntity>> expression)
        {
            throw new NotImplementedException();
        }

        public static IUpdateStatement Update<TEntity>(this IUpdatableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete statement methods

        public static IDeleteStatement Delete<TEntity>(this IBatchDeletableStatement<TEntity> statement)
        {
            throw new NotImplementedException();
        }

        public static IDeleteStatement Delete<TEntity>(this IDeletableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fluent Query building 

        public static IJoinableViewStatement<TEntity> Join<TEntity, TReference>(this IJoinableViewStatement<TEntity> statement, Expression<Func<TEntity, TReference>> expression)
        {
            throw new NotImplementedException();
        }

        public static IJoinableTableStatement<TEntity> Join<TEntity, TReference>(this IJoinableTableStatement<TEntity> statement, Expression<Func<TEntity, TReference>> expression)
        {
            throw new NotImplementedException();
        }

        public static IWherableViewStatement<TEntity> Where<TEntity>(this IWherableViewStatement<TEntity> statement, Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public static IWherableTableStatement<TEntity> Where<TEntity>(this IWherableTableStatement<TEntity> statement, Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public static IOrderableStatement<TDestination> Select<TEntity, TDestination>(this ISelectableStatement<TEntity> statement, Expression<Func<TEntity, TDestination>> expression)
        {
            throw new NotImplementedException();
        }

        public static IOrderableStatement<TEntity> OrderBy<TEntity, TColumn>(this IOrderableStatement<TEntity> statement, Expression<Func<TEntity, TColumn>> expression)
        {
            throw new NotImplementedException();
        }

        public static IOrderableStatement<TEntity> OrderByDescending<TEntity, TColumn>(this IOrderableStatement<TEntity> statement, Expression<Func<TEntity, TColumn>> expression)
        {
            throw new NotImplementedException();
        }

        public static ITakeableStatement<TEntity> Skip<TEntity>(this ISkippableStatement<TEntity> statement, int skip)
        {
            throw new NotImplementedException();
        }

        public static ISelectableStatement<TEntity> Take<TEntity>(this ITakeableStatement<TEntity> statement, int take)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Shortcut execution calls

        public static List<TEntity> ExecuteQuery<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return statement.Query().Execute();
        }

        public static async Task<List<TEntity>> ExecuteQueryAsync<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return await statement.Query().ExecuteAsync().ConfigureAwait(false);
        }

        public static TEntity ExecuteQuerySingle<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return statement.QuerySingle().Execute();
        }

        public static async Task<TEntity> ExecuteQuerySingleAsync<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return await statement.QuerySingle().ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteCount<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return statement.Count().Execute();
        }

        public static async Task<int> ExecuteCountAsync<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return await statement.Count().ExecuteAsync().ConfigureAwait(false);
        }

        public static bool ExecuteExists<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return statement.Exists().Execute();
        }

        public static async Task<bool> ExecuteExistsAsync<TEntity>(this IQueryableStatement<TEntity> statement)
        {
            return await statement.Exists().ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteInsert<TDatabase, TEntity>(this IInsertableStatement<TDatabase, TEntity> statement, Expression<Func<TDatabase, IQueryStatement<TEntity>>> expression) where TDatabase : IDatabase
        {
            return statement.Insert(expression).Execute();
        }

        public static async Task<int> ExecuteInsertAsync<TDatabase, TEntity>(this IInsertableStatement<TDatabase, TEntity> statement, Expression<Func<TDatabase, IQueryStatement<TEntity>>> expression) where TDatabase : IDatabase
        {
            return await statement.Insert(expression).ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteInsert<TDatabase, TEntity>(this IInsertableStatement<TDatabase, TEntity> statement, Expression<Func<TDatabase, IQueryStatement<List<TEntity>>>> expression) where TDatabase : IDatabase
        {
            return statement.Insert(expression).Execute();
        }

        public static async Task<int> ExecuteInsertAsync<TDatabase, TEntity>(this IInsertableStatement<TDatabase, TEntity> statement, Expression<Func<TDatabase, IQueryStatement<List<TEntity>>>> expression) where TDatabase : IDatabase
        {
            return await statement.Insert(expression).ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteInsert<TEntity>(this IInsertableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            return statement.Insert(entity, entities).Execute();
        }

        public static async Task<int> ExecuteInsertAsync<TEntity>(this IInsertableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            return await statement.Insert(entity, entities).ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteUpdate<TEntity>(this IBatchUpdatableStatement<TEntity> statement, Expression<Func<TEntity, TEntity>> expression)
        {
            return statement.Update(expression).Execute();
        }

        public static async Task<int> ExecuteUpdateAsync<TEntity>(this IBatchUpdatableStatement<TEntity> statement, Expression<Func<TEntity, TEntity>> expression)
        {
            return await statement.Update(expression).ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteUpdate<TEntity>(this IUpdatableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            return statement.Update(entity, entities).Execute();
        }

        public static async Task<int> ExecuteUpdateAsync<TEntity>(this IUpdatableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            return await statement.Update(entity, entities).ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteDelete<TEntity>(this IBatchDeletableStatement<TEntity> statement)
        {
            return statement.Delete().Execute();
        }

        public static async Task<int> ExecuteDeleteAsync<TEntity>(this IBatchDeletableStatement<TEntity> statement)
        {
            return await statement.Delete().ExecuteAsync().ConfigureAwait(false);
        }

        public static int ExecuteDelete<TEntity>(this IDeletableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            return statement.Delete(entity, entities).Execute();
        }

        public static async Task<int> ExecuteDeleteAsync<TEntity>(this IDeletableStatement<TEntity> statement, TEntity entity, params TEntity[] entities)
        {
            return await statement.Delete(entity, entities).ExecuteAsync().ConfigureAwait(false);
        }

        #endregion
    }
}

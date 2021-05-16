using Crocodal.Builders;
using Crocodal.Core.Statements;
using Crocodal.Internal.Sourcing;
using System;
using System.Linq.Expressions;

namespace Crocodal
{
    public static class StatementExtensions
    {
        #region Statement building starting points

        public static IQueryBuilder<TSource> Query<TSource>(this IQueryable<TSource> source, Action<QueryOptionsBuilder> options = null)
        {
            return new QueryBuilder<TSource>(((ISourcable)source).GetDatabase(), options);
        }

        public static IInsert InsertFrom<TSource>(this IInsertable<TSource> source, IQuery<TSource> from)
        {
            return new InsertFromStatement<TSource>(((ISourcable)source).GetDatabase(), from);
        }

        public static IInsert Insert<TSource>(this IInsertable<TSource> source, TSource entity, params TSource[] entities)
        {
            return new InsertStatement(((ISourcable)source).GetDatabase(), entity, entities);
        }

        public static IUpdateBuilder<TSource> Update<TSource>(this IUpdatable<TSource> source)
        {
            return new UpdateBuilder<TSource>(((ISourcable)source).GetDatabase());
        }

        public static IUpdate Update<TSource>(this IInsertable<TSource> source, TSource entity, params TSource[] entities)
        {
            return new UpdateStatement(((ISourcable)source).GetDatabase(), entity, entities);
        }

        public static IDeleteBuilder<TSource> Delete<TSource>(this IDeletable<TSource> source)
        {
            return new DeleteBuilder<TSource>(((ISourcable)source).GetDatabase());
        }

        public static IDelete Delete<TSource>(this IInsertable<TSource> source, TSource entity, params TSource[] entities)
        {
            return new DeleteStatement(((ISourcable)source).GetDatabase(), entity, entities);
        }

        #endregion

        #region Fluent Query building 

        public static IJoinableQuery<TSource> Join<TSource, TNavigation>(this IJoinableQuery<TSource> statement, Expression<Func<TSource, TNavigation>> expression)
        {
            throw new NotImplementedException();
        }

        public static IJoinableQuery<TSource1, TSource2> Join<TSource1, TSource2>(this IJoinableQuery<TSource1> statement, IQuery<TSource2> join, Expression<Func<TSource1, TSource2, bool>> on)
        {
            throw new NotImplementedException();
        }

        public static IWherableQuery<TSource> Where<TSource>(this IWherableQuery<TSource> statement, Expression<Func<TSource, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public static IOrderableQuery<TSource> OrderBy<TSource, TColumn>(this IOrderableQuery<TSource> statement, Expression<Func<TSource, TColumn>> expression)
        {
            throw new NotImplementedException();
        }

        public static IOrderableQuery<TSource> OrderByDescending<TSource, TColumn>(this IOrderableQuery<TSource> statement, Expression<Func<TSource, TColumn>> expression)
        {
            throw new NotImplementedException();
        }

        public static ITakeableQuery<TSource> Skip<TSource>(this ISkippableQuery<TSource> statement, int skip)
        {
            throw new NotImplementedException();
        }

        public static ISelectableQuery<TSource> Take<TSource>(this ITakeableQuery<TSource> statement, int take)
        {
            throw new NotImplementedException();
        }

        public static IJoinableQuery<TDestination> Select<TSource, TDestination>(this ISelectableQuery<TSource> statement, Expression<Func<TSource, TDestination>> expression)
        {
            throw new NotImplementedException();
        }

        public static IJoinableQuery<TDestination> Select<TSource1, TSource2, TDestination>(this ISelectableQuery<TSource1, TSource2> statement, Expression<Func<TSource1, TSource2, TDestination>> expression)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<TSource> Union<TSource>(this IUnionableQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        public static IUnionableQuery<TSource> Union<TSource>(this IUnionableQuery<TSource> statement, IQuery<TSource> other)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<TSource> UnionAll<TSource>(this IUnionableQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        public static IUnionableQuery<TSource> UnionAll<TSource>(this IUnionableQuery<TSource> statement, IQuery<TSource> other)
        {
            throw new NotImplementedException();
        }

        public static IExecutable<TSource> First<TSource>(this IQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }
        public static IExecutable<TSource> FirstOrDefault<TSource>(this IQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        public static IExecutable<TSource> Single<TSource>(this IQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        public static IExecutable<TSource> SingleOrDefault<TSource>(this IQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        public static IExecutable<int> Count<TSource>(this IQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        public static IExecutable<bool> Exists<TSource>(this IQuery<TSource> statement)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fluent Update building

        public static IWherableUpdate<TSource> Where<TSource>(this IWherableUpdate<TSource> statement, Expression<Func<TSource, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public static ISettableUpdate<TSource> Set<TSource, TValue>(this ISettableUpdate<TSource> statement, Expression<Func<TSource, TValue>> column, Expression<Func<TSource, TValue>> expression)
        {
            throw new NotImplementedException();
        }

        public static ISettableUpdate<TSource> Set<TSource, TValue>(this ISettableUpdate<TSource> statement, Expression<Func<TSource, TValue>> column, TValue value)
        {
            throw new NotImplementedException();
        }

        public static IUpdate Set<TSource>(this ISettableUpdate<TSource> statement, Expression<Func<TSource, TSource>> expression)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fluent Delete building

        public static IWherableDelete<TSource> Where<TSource>(this IWherableDelete<TSource> statement, Expression<Func<TSource, bool>> expression)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

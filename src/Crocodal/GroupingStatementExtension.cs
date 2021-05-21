using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crocodal
{
    public static class GroupingStatementExtension
    {
        public static IJoinableGrouping<TKey, TValue> Join<TKey, TValue, TNavigation>(this IJoinableGrouping<TKey, TValue> statement, Expression<Func<TValue, TNavigation>> expression)
        {
            throw new NotImplementedException();
        }

        public static IWherableGrouping<TKey, TValue> Where<TKey, TValue>(this IWherableGrouping<TKey, TValue> statement, Expression<Func<TValue, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public static IExecutableGrouping<TKey, TValue> Select<TKey, TValue, TDestination>(this ISelectableGrouping<TKey, TValue> statement, Expression<Func<TValue, TDestination>> expression)
        {
            throw new NotImplementedException();
        }

        public static decimal Average<TKey, TValue>(this IAggregableGrouping<TKey, TValue> group, Expression<Func<TValue, decimal>> expression)
        {
            throw new NotImplementedException();
        }

        public static int Count<TKey, TValue>(this IAggregableGrouping<TKey, TValue> group)
        {
            throw new NotImplementedException();
        }

        public static decimal Max<TKey, TValue>(this IAggregableGrouping<TKey, TValue> group, Expression<Func<TValue, decimal>> expression)
        {
            throw new NotImplementedException();
        }

        public static decimal Min<TKey, TValue>(this IAggregableGrouping<TKey, TValue> group, Expression<Func<TValue, decimal>> expression)
        {
            throw new NotImplementedException();
        }

        public static decimal Sum<TKey, TValue>(this IAggregableGrouping<TKey, TValue> group, Expression<Func<TValue, decimal>> expression)
        {
            throw new NotImplementedException();
        }

        public static List<TValue> AsList<TKey, TValue>(this IExecutableGrouping<TKey, TValue> group)
        {
            throw new NotImplementedException();
        }

        public static TValue[] AsArray<TKey, TValue>(this IExecutableGrouping<TKey, TValue> group)
        {
            throw new NotImplementedException();
        }
    }
}

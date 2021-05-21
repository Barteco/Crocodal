﻿using System.Collections.Generic;

namespace Crocodal
{
    public interface IQueryable<TSource>
    {
    }

    public interface IArrayQuery<TSource> : IExecutable<TSource[]>
    {
    }

    public interface IDictionaryQuery<TKey, TSource> : IExecutable<Dictionary<TKey, TSource>>
    {
    }

    public interface IQuery<TSource> : ISource<TSource>, IExecutable<List<TSource>>
    {
    }

    public interface IUnionableQuery<TSource> : IQuery<TSource>
    {
    }

    public interface IAggregableQuery<TSource> : IUnionableQuery<TSource>
    {
    }

    public interface IDistinctableQuery<TSource> : IAggregableQuery<TSource>
    {
    }

    public interface ISelectableQuery<TSource> : IDistinctableQuery<TSource>
    {
    }

    public interface ITakeableQuery<TSource> : ISelectableQuery<TSource>
    {
    }

    public interface ISkippableQuery<TSource> : ITakeableQuery<TSource>
    {
    }

    public interface IOrderableQuery<TSource> : ISkippableQuery<TSource>
    {
    }

    public interface IHavingableQuery<TSource> : IOrderableQuery<TSource>
    {
    }

    public interface IGroupableQuery<TSource> : IOrderableQuery<TSource>
    {
    }

    public interface IWherableQuery<TSource> : IGroupableQuery<TSource>
    {
    }

    public interface IJoinableQuery<TSource> : IWherableQuery<TSource>
    {
    }

    public interface IQueryBuilder<TSource> : IJoinableQuery<TSource>
    {
    }
}
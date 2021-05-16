using System.Collections.Generic;

namespace Crocodal
{
    public interface IQueryable<TSource>
    {
    }

    public interface IQuery<TSource> : IExecutable<List<TSource>>
    {
    }

    public interface IUnionableQuery<TSource> : IQuery<TSource>
    {
    }

    public interface ISelectableQuery<TSource> : IUnionableQuery<TSource>
    {
    }

    public interface ISelectableQuery<TSource1, TSource2> : IUnionableQuery<TSource1>
    {
    }

    public interface ITakeableQuery<TSource> : ISelectableQuery<TSource>
    {
    }

    public interface ITakeableQuery<TSource1, TSource2> : ISelectableQuery<TSource1, TSource2>
    {
    }

    public interface ISkippableQuery<TSource> : ITakeableQuery<TSource>
    {
    }

    public interface ISkippableQuery<TSource1, TSource2> : ITakeableQuery<TSource1, TSource2>
    {
    }

    public interface IOrderableQuery<TSource> : ISkippableQuery<TSource>
    {
    }

    public interface IOrderableQuery<TSource1, TSource2> : ISkippableQuery<TSource1, TSource2>
    {
    }

    public interface IWherableQuery<TSource> : IOrderableQuery<TSource>
    {
    }

    public interface IWherableQuery<TSource1, TSource2> : IOrderableQuery<TSource1, TSource2>
    {
    }


    public interface IJoinableQuery<TSource> : IWherableQuery<TSource>
    {
    }

    public interface IJoinableQuery<TSource1, TSource2> : IWherableQuery<TSource1, TSource2>
    {
    }

    public interface IQueryBuilder<TSource> : IJoinableQuery<TSource>
    {
    }
}
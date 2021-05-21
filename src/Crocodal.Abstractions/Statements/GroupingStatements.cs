namespace Crocodal
{
    public interface IGrouping<TKey, TSource>
    {
        TKey Key { get; }
    }

    public interface IAggregableGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
    }

    public interface IExecutableGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
    }

    public interface ISelectableGrouping<TKey, TSource> : IExecutableGrouping<TKey, TSource>
    {
    }

    public interface IWherableGrouping<TKey, TSource> : ISelectableGrouping<TKey, TSource>, IAggregableGrouping<TKey, TSource>
    {
    }

    public interface IJoinableGrouping<TKey, TSource> : IWherableGrouping<TKey, TSource>
    {
    }

    public interface IGroupingBuilder<TKey, TSource> : IJoinableGrouping<TKey, TSource>
    {
    }
}
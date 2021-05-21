namespace Crocodal
{
    public interface ITable<TSource> : IQueryable<TSource>, IInsertable<TSource>, IUpdatable<TSource>, IDeletable<TSource>, ISource<TSource>
    {
    }

    public interface IView<TSource> : IQueryable<TSource>, ISource<TSource>
    {
    }

    public interface IFunction<TResult> : IExecutable<TResult>
    {
    }

    public interface IStoredProcedure<TResult> : IExecutable<TResult>
    {
    }

    public interface ISource<TSource>
    {
    }
}

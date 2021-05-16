namespace Crocodal
{
    public interface ITable<TSource> : IQueryable<TSource>, IInsertable<TSource>, IUpdatable<TSource>, IDeletable<TSource>
    {
    }

    public interface IView<TSource> : IQueryable<TSource>
    {
    }

    public interface IFunction<TResult> : IExecutable<TResult>
    {
    }

    public interface IStoredProcedure<TResult> : IExecutable<TResult>
    {
    }
}

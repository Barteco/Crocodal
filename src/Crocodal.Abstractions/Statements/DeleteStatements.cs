namespace Crocodal
{
    public interface IDeletable<TSource>
    {
    }

    public interface IDelete : IExecutable<int>
    {
    }

    public interface IWherableDelete<TSource> : IDelete
    {
    }

    public interface IDeleteBuilder<TSource> : IWherableDelete<TSource>
    {
    }
}

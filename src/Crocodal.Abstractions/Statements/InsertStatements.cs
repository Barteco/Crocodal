namespace Crocodal
{
    public interface IInsertable<TSource>
    {
    }

    public interface IInsert : IExecutable<int>
    {
    }

    public interface IInsertBuilder<TSource> : IInsert
    {
    }
}

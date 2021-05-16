namespace Crocodal
{
    public interface IUpdatable<TSource>
    {
    }

    public interface IUpdate : IExecutable<int>
    {
    }

    public interface ISettableUpdate<TSource> : IUpdate
    {
    }

    public interface IWherableUpdate<TSource> : ISettableUpdate<TSource>
    {
    }

    public interface IUpdateBuilder<TSource> : IWherableUpdate<TSource>
    {
    }
}

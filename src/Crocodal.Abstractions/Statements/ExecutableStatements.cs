namespace Crocodal
{
    public interface IExecutable<TResult> : IExecutable
    {
    }

    public interface IExecutable
    {
    }

    public interface IBuilder
    {
        IDatabase Database { get; }
        ISqlExpression Build();
    }

    public interface ISqlExpression
    {
    }
}

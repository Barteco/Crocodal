namespace Crocodal
{
    public interface IQueryStatement<TResult> : IExecutableStatement<TResult>
    {
    }

    public interface IInsertStatement : IExecutableStatement<int>
    {
    }

    public interface IUpdateStatement : IExecutableStatement<int>
    {
    }

    public interface IDeleteStatement : IExecutableStatement<int>
    {
    }
}

using System.Threading.Tasks;

namespace Crocodal
{
    public interface IDatabase
    {
        TResult Execute<TResult>(IExecutableStatement<TResult> statement);
        Task<TResult> ExecuteAsync<TResult>(IExecutableStatement<TResult> statement);
        string ToSqlString<TResult>(IExecutableStatement<TResult> statement);
    }
}
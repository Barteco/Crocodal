using System.Threading.Tasks;

namespace Crocodal
{
    public interface IDatabase
    {
        TResult Execute<TResult>(IExecutable<TResult> statement);
        Task<TResult> ExecuteAsync<TResult>(IExecutable<TResult> statement);
        string ToSqlString<TResult>(IExecutable<TResult> statement);
    }
}
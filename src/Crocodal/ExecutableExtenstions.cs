using Crocodal.Core.Statements.Abstract;
using System.Threading.Tasks;

namespace Crocodal
{
    public static class ExecutableExtenstions
    {
        public static TResult Execute<TResult>(this IExecutable<TResult> statement)
        {
            return (statement as ExecutableStatement<TResult>).Database.Execute(statement);
        }

        public static async Task<TResult> ExecuteAsync<TResult>(this IExecutable<TResult> statement)
        {
            return await (statement as ExecutableStatement<TResult>).Database.ExecuteAsync(statement).ConfigureAwait(false);
        }

        public static string ToSqlString<TResult>(this IExecutable<TResult> statement)
        {
            return (statement as ExecutableStatement<TResult>).Database.ToSqlString(statement);
        }
    }
}
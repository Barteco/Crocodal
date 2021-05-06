using System.Threading.Tasks;

namespace Crocodal
{
    public static class ExecutableExtenstions
    {
        public static TResult Execute<TResult>(this IExecutableStatement<TResult> statement)
        {
            return (statement as DatabaseStatement<TResult>).Database.Execute(statement);
        }

        public static async Task<TResult> ExecuteAsync<TResult>(this IExecutableStatement<TResult> statement)
        {
            return await (statement as DatabaseStatement<TResult>).Database.ExecuteAsync(statement).ConfigureAwait(false);
        }

        public static string ToSqlString<TResult>(this IExecutableStatement<TResult> statement)
        {
            return (statement as DatabaseStatement<TResult>).Database.ToSqlString(statement);
        }
    }
}
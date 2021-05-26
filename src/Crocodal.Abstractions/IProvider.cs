using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crocodal
{
    public interface IProvider
    {
        object[] Execute(IEnumerable<ISqlExpression> statements);
        Task<object[]> ExecuteAsync(IEnumerable<ISqlExpression> statements);
        T Execute<T>(string sql, params object[] parameters);
        Task<T> ExecuteAsync<T>(string sql, params object[] parameters);
        string ToSqlString(IExecutable statement);
    }
}
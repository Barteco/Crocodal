using System.Threading.Tasks;

namespace Crocodal
{
    public interface IProvider
    {
        object[] Execute(params IExecutable[] statements);
        Task<object[]> ExecuteAsync(params IExecutable[] statements);
        string ToSqlString(IExecutable statement);
    }
}
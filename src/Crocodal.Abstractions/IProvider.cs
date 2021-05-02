using System.Threading.Tasks;

namespace Crocodal
{
    public interface IProvider
    {
        object[] Execute(params IExecutableStatement[] statements);
        Task<object[]> ExecuteAsync(params IExecutableStatement[] statements);
        string ToSqlString(IExecutableStatement statement);
    }
}
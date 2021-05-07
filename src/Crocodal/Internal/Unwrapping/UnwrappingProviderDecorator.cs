using System.Threading.Tasks;

namespace Crocodal.Internal.Unwrapping
{
    internal class UnwrappingProviderDecorator : IProvider
    {
        private readonly IProvider _provider;

        public UnwrappingProviderDecorator(IProvider provider)
        {
            _provider = provider;
        }

        public object[] Execute(params IExecutableStatement[] statements)
        {
            return _provider.Execute(UnwrapAll(statements));
        }

        public async Task<object[]> ExecuteAsync(params IExecutableStatement[] statements)
        {
            return await _provider.ExecuteAsync(UnwrapAll(statements)).ConfigureAwait(false);
        }

        public string ToSqlString(IExecutableStatement statement)
        {
            return _provider.ToSqlString(UnwrapAll(statement)[0]);
        }

        private IExecutableStatement[] UnwrapAll(params IExecutableStatement[] statements)
        {
            for (int i = 0; i < statements.Length; i++)
            {
                if (statements[i] is IUnwrappable wrappable)
                {
                    statements[i] = wrappable.Unwrap();
                }
            }

            return statements;
        }
    }
}

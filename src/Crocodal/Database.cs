using Crocodal.Internal.Utilities;
using Crocodal.Statements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crocodal
{
    public abstract partial class Database : IDatabase
    {
        protected IProvider Provider { get; }

        public virtual void Configure(IDatabaseBuilder builder)
        {
            // auto-discover configuration from assembly
        }

        #region Dispath to provider

        public TResult Execute<TResult>(IExecutableStatement<TResult> statement)
        {
            return Provider.Execute(statement)
                .Map<TResult>();
        }

        public (TResult1, TResult2) Execute<TResult1, TResult2>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2)
        {
            return Provider.Execute(statement1, statement2)
                .Map<TResult1, TResult2>();
        }

        public (TResult1, TResult2, TResult3) Execute<TResult1, TResult2, TResult3>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3)
        {
            return Provider.Execute(statement1, statement2, statement3)
                .Map<TResult1, TResult2, TResult3>();
        }

        public (TResult1, TResult2, TResult3, TResult4) Execute<TResult1, TResult2, TResult3, TResult4>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4)
                .Map<TResult1, TResult2, TResult3, TResult4>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5) Execute<TResult1, TResult2, TResult3, TResult4, TResult5>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5)
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5, IExecutableStatement<TResult6> statement6)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5, statement6)
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5, IExecutableStatement<TResult6> statement6, IExecutableStatement<TResult7> statement7)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5, statement6, statement7)
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5, IExecutableStatement<TResult6> statement6, IExecutableStatement<TResult7> statement7, IExecutableStatement<TResult8> statement8)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8)
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>();
        }

        public async Task<TResult> ExecuteAsync<TResult>(IExecutableStatement<TResult> statement)
        {
            return (await Provider.ExecuteAsync(statement).ConfigureAwait(false))
                .Map<TResult>();
        }

        public async Task<(TResult1, TResult2)> ExecuteAsync<TResult1, TResult2>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2)
        {
            return (await Provider.ExecuteAsync(statement1, statement2).ConfigureAwait(false))
                .Map<TResult1, TResult2>();
        }

        public async Task<(TResult1, TResult2, TResult3)> ExecuteAsync<TResult1, TResult2, TResult3>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3).ConfigureAwait(false))
                .Map<TResult1, TResult2, TResult3>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4).ConfigureAwait(false))
                .Map<TResult1, TResult2, TResult3, TResult4>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5).ConfigureAwait(false))
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5, IExecutableStatement<TResult6> statement6)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5, statement6).ConfigureAwait(false))
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5, IExecutableStatement<TResult6> statement6, IExecutableStatement<TResult7> statement7)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5, statement6, statement7).ConfigureAwait(false))
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(IExecutableStatement<TResult1> statement1, IExecutableStatement<TResult2> statement2, IExecutableStatement<TResult3> statement3, IExecutableStatement<TResult4> statement4, IExecutableStatement<TResult5> statement5, IExecutableStatement<TResult6> statement6, IExecutableStatement<TResult7> statement7, IExecutableStatement<TResult8> statement8)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8).ConfigureAwait(false))
                .Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>();
        }

        public TResult ExecuteSql<TResult>(string sql, object parameters)
        {
            return Provider.Execute(new RawSqlStatement<TResult>(this, sql, parameters))
                .Map<TResult>();
        }

        public async Task<TResult> ExecuteSqlAsync<TResult>(string sql, object parameters)
        {
            return (await Provider.ExecuteAsync(new RawSqlStatement<TResult>(this, sql, parameters)).ConfigureAwait(false))
                .Map<TResult>();
        }

        public string ToSqlString<TResult>(IExecutableStatement<TResult> statement)
        {
            return Provider.ToSqlString(statement);
        } 

        #endregion
    }
}
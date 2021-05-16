using Crocodal.Builders;
using Crocodal.Core.Statements;
using Crocodal.Internal.Utilities;
using System;
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

        #region Execute(Async) methods

        public TResult Execute<TResult>(IExecutable<TResult> statement)
        {
            return Provider.Execute(statement)
                .ToTuple<TResult>();
        }

        public (TResult1, TResult2) Execute<TResult1, TResult2>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2)
        {
            return Provider.Execute(statement1, statement2)
                .ToTuple<TResult1, TResult2>();
        }

        public (TResult1, TResult2, TResult3) Execute<TResult1, TResult2, TResult3>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3)
        {
            return Provider.Execute(statement1, statement2, statement3)
                .ToTuple<TResult1, TResult2, TResult3>();
        }

        public (TResult1, TResult2, TResult3, TResult4) Execute<TResult1, TResult2, TResult3, TResult4>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4)
                .ToTuple<TResult1, TResult2, TResult3, TResult4>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5) Execute<TResult1, TResult2, TResult3, TResult4, TResult5>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5)
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5, statement6)
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5, statement6, statement7)
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7, IExecutable<TResult8> statement8)
        {
            return Provider.Execute(statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8)
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>();
        }

        public async Task<TResult> ExecuteAsync<TResult>(IExecutable<TResult> statement)
        {
            return (await Provider.ExecuteAsync(statement).ConfigureAwait(false))
                .ToTuple<TResult>();
        }

        public async Task<(TResult1, TResult2)> ExecuteAsync<TResult1, TResult2>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2)
        {
            return (await Provider.ExecuteAsync(statement1, statement2).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2>();
        }

        public async Task<(TResult1, TResult2, TResult3)> ExecuteAsync<TResult1, TResult2, TResult3>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5, statement6).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5, statement6, statement7).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7, IExecutable<TResult8> statement8)
        {
            return (await Provider.ExecuteAsync(statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>();
        }

        #endregion

        #region ExecuteSql(Async) methods

        public TResult ExecuteSql<TResult>(string sql, object parameters)
        {
            return Provider.Execute(new RawSqlStatement<TResult>(this, sql, parameters))
                .ToTuple<TResult>();
        }

        public async Task<TResult> ExecuteSqlAsync<TResult>(string sql, object parameters)
        {
            return (await Provider.ExecuteAsync(new RawSqlStatement<TResult>(this, sql, parameters)).ConfigureAwait(false))
                .ToTuple<TResult>();
        }

        #endregion

        #region Query/Insert/Update/Delete

        public IQueryBuilder<TResult> Query<TResult>()
        {
            return new QueryBuilder<TResult>(this, null);
        }

        public IQueryBuilder<TResult> Query<TResult>(Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<TResult>(this, options);
        }

        public IQueryBuilder<TResult> Query<TResult>(IQuery<TResult> from)
        {
            return new QueryBuilder<TResult>(this, null);
        }

        public IQueryBuilder<TResult> Query<TResult>(IQuery<TResult> from, Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<TResult>(this, options);
        }

        public IInsert Insert(object entity, params object[] entities)
        {
            return new InsertStatement(this, entity, entities);
        }

        public IUpdate Update(object entity, params object[] entities)
        {
            return new UpdateStatement(this, entity, entities);
        }

        public IDelete Delete(object entity, params object[] entities)
        {
            return new DeleteStatement(this, entity, entities);
        }

        #endregion

        #region Diagnostics

        public string ToSqlString<TResult>(IExecutable<TResult> statement)
        {
            return Provider.ToSqlString(statement);
        }

        #endregion
    }
}
using Crocodal.Builders;
using Crocodal.Internal.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crocodal
{
    public abstract partial class Database : IDatabase
    {
        #region Members

        protected IProvider Provider { get; }
        protected DatabaseOptions Options { get; }

        #endregion

        #region Configuration

        public Database()
        {
        }

        public Database(Action<DatabaseOptionsBuilder> configuration)
        {
        }

        protected virtual void Configure(IDatabaseBuilder builder)
        {
            // auto-discover configuration from assembly
        }

        #endregion

        #region Execute(Async) methods

        public TResult Execute<TResult>(IExecutable<TResult> statement)
        {
            return Provider.Execute(Build(statement))
                .ToTuple<TResult>();
        }

        public (TResult1, TResult2) Execute<TResult1, TResult2>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2)
        {
            return Provider.Execute(Build(statement1, statement2))
                .ToTuple<TResult1, TResult2>();
        }

        public (TResult1, TResult2, TResult3) Execute<TResult1, TResult2, TResult3>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3)
        {
            return Provider.Execute(Build(statement1, statement2, statement3))
                .ToTuple<TResult1, TResult2, TResult3>();
        }

        public (TResult1, TResult2, TResult3, TResult4) Execute<TResult1, TResult2, TResult3, TResult4>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4)
        {
            return Provider.Execute(Build(statement1, statement2, statement3, statement4))
                .ToTuple<TResult1, TResult2, TResult3, TResult4>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5) Execute<TResult1, TResult2, TResult3, TResult4, TResult5>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5)
        {
            return Provider.Execute(Build(statement1, statement2, statement3, statement4, statement5))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6)
        {
            return Provider.Execute(Build(statement1, statement2, statement3, statement4, statement5, statement6))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7)
        {
            return Provider.Execute(Build(statement1, statement2, statement3, statement4, statement5, statement6, statement7))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>();
        }

        public (TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8) Execute<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7, IExecutable<TResult8> statement8)
        {
            return Provider.Execute(Build(statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>();
        }

        public async Task<TResult> ExecuteAsync<TResult>(IExecutable<TResult> statement)
        {
            return (await Provider.ExecuteAsync(Build(statement)).ConfigureAwait(false))
                .ToTuple<TResult>();
        }

        public async Task<(TResult1, TResult2)> ExecuteAsync<TResult1, TResult2>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2>();
        }

        public async Task<(TResult1, TResult2, TResult3)> ExecuteAsync<TResult1, TResult2, TResult3>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2, statement3)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2, statement3, statement4)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2, statement3, statement4, statement5)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2, statement3, statement4, statement5, statement6)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2, statement3, statement4, statement5, statement6, statement7)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>();
        }

        public async Task<(TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8)> ExecuteAsync<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(IExecutable<TResult1> statement1, IExecutable<TResult2> statement2, IExecutable<TResult3> statement3, IExecutable<TResult4> statement4, IExecutable<TResult5> statement5, IExecutable<TResult6> statement6, IExecutable<TResult7> statement7, IExecutable<TResult8> statement8)
        {
            return (await Provider.ExecuteAsync(Build(statement1, statement2, statement3, statement4, statement5, statement6, statement7, statement8)).ConfigureAwait(false))
                .ToTuple<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>();
        }

        #endregion

        #region ExecuteSql(Async) methods

        public TResult ExecuteSql<TResult>(string sql, object parameters)
        {
            return Provider.Execute<TResult>(sql, parameters);
        }

        public async Task<TResult> ExecuteSqlAsync<TResult>(string sql, object parameters)
        {
            return await Provider.ExecuteAsync<TResult>(sql, parameters).ConfigureAwait(false);
        }

        #endregion

        #region Query/Insert/Update/Delete

        public IQueryBuilder<TSource> Query<TSource>()
        {
            return new QueryBuilder<TSource>(this, null);
        }

        public IQueryBuilder<TSource> Query<TSource>(Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<TSource>(this, options);
        }

        public IQueryBuilder<(TSource1, TSource2)> Query<TSource1, TSource2>()
        {
            return new QueryBuilder<(TSource1, TSource2)>(this, null);
        }

        public IQueryBuilder<(TSource1, TSource2)> Query<TSource1, TSource2>(Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<(TSource1, TSource2)>(this, options);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3)> Query<TSource1, TSource2, TSource3>()
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3)>(this, null);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3)> Query<TSource1, TSource2, TSource3>(Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3)>(this, options);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3, TSource4)> Query<TSource1, TSource2, TSource3, TSource4>()
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3, TSource4)>(this, null);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3, TSource4)> Query<TSource1, TSource2, TSource3, TSource4>(Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3, TSource4)>(this, options);
        }

        public IQueryBuilder<TSource> Query<TSource>(ISource<TSource> from)
        {
            return new QueryBuilder<TSource>(this, null);
        }

        public IQueryBuilder<TSource> Query<TSource>(ISource<TSource> from, Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<TSource>(this, options);
        }

        public IQueryBuilder<(TSource1, TSource2)> Query<TSource1, TSource2>(ISource<TSource1> from1, ISource<TSource2> from2)
        {
            return new QueryBuilder<(TSource1, TSource2)>(this, null);
        }

        public IQueryBuilder<(TSource1, TSource2)> Query<TSource1, TSource2>(ISource<TSource1> from1, ISource<TSource2> from2, Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<(TSource1, TSource2)>(this, options);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3)> Query<TSource1, TSource2, TSource3>(ISource<TSource1> from1, ISource<TSource2> from2, ISource<TSource3> from3)
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3)>(this, null);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3)> Query<TSource1, TSource2, TSource3>(ISource<TSource1> from1, ISource<TSource2> from2, ISource<TSource3> from3, Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3)>(this, options);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3, TSource4)> Query<TSource1, TSource2, TSource3, TSource4>(ISource<TSource1> from1, ISource<TSource2> from2, ISource<TSource3> from3, ISource<TSource4> from4)
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3, TSource4)>(this, null);
        }

        public IQueryBuilder<(TSource1, TSource2, TSource3, TSource4)> Query<TSource1, TSource2, TSource3, TSource4>(ISource<TSource1> from1, ISource<TSource2> from2, ISource<TSource3> from3, ISource<TSource4> from4, Action<QueryOptionsBuilder> options)
        {
            return new QueryBuilder<(TSource1, TSource2, TSource3, TSource4)>(this, options);
        }

        public IInsert Insert(object entity, params object[] entities)
        {
            return new InsertBuilder<object>(this);
        }

        public IUpdate Update(object entity, params object[] entities)
        {
            return new UpdateBuilder<object>(this);
        }

        public IDelete Delete(object entity, params object[] entities)
        {
            return new DeleteBuilder<object>(this);
        }

        #endregion

        #region Diagnostics

        public string ToSqlString<TResult>(IExecutable<TResult> statement)
        {
            return Provider.ToSqlString(statement);
        }

        #endregion

        #region Private

        private IEnumerable<ISqlExpression> Build(params IExecutable[] statements)
        {
            foreach (var statement in statements)
            {
                yield return (statement as IBuilder).Build();
            }
        }

        #endregion
    }
}
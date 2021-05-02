using System;
using System.Linq.Expressions;

namespace Crocodal
{
    public partial interface ITableBuilder<TEntity> : IObjectBuilder<ITableBuilder<TEntity>>
    {
        IPrimaryKeyBuilder<TColumn> SetPrimaryKey<TColumn>(Expression<Func<TEntity, TColumn>> expression);
        IForeignKeyBuilder<TEntity, TReference> SetForeignKey<TReference>(Expression<Func<TEntity, object>> keyExpression, Expression<Func<TEntity, TReference>> objectExpression);
        IColumnBuilder<TColumn> SetColumn<TColumn>(Expression<Func<TEntity, TColumn>> expression);
        ITableBuilder<TEntity> SetIndex();
        ITableBuilder<TEntity> SetUniqueIndex();
        ITableBuilder<TEntity> SetHint();
    }

    // in SQL Server 2017 Provider
    public partial interface ITableBuilder<TEntity>
    {
        ITableBuilder<TEntity> AsNode();
        ITableBuilder<TEntity> AsEdge();
    }
}

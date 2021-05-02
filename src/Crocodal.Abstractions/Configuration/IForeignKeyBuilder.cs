using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crocodal
{
    public interface IForeignKeyBuilder<TSource, TReference>
    {
        IForeignKeyBuilder<TSource, TReference> References<TSourceCollection>(Expression<Func<TReference, object>> keyExpression, Expression<Func<TReference, TSourceCollection>> objectExpression) where TSourceCollection : ICollection<TSource>;
        IForeignKeyBuilder<TSource, TReference> SetConstraintName(string name);
        IForeignKeyBuilder<TSource, TReference> SetOnUpdate(UpdateRule updateRule);
        IForeignKeyBuilder<TSource, TReference> SetOnDelete(DeleteRule deleteRule);
    }
}

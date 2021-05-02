using System;
using System.Linq.Expressions;

namespace Crocodal
{
    public interface IColumnBuilder<TColumn>
    {
        IColumnBuilder<TColumn> SetNonClusteredIndex();
        IColumnBuilder<TColumn> SetClusteredIndex();
        IColumnBuilder<TColumn> SetUniqueIndex();
        IColumnBuilder<TColumn> SetName(string name);
        IColumnBuilder<TColumn> SetConverter<TConverter>();
        IColumnBuilder<TColumn> SetDefaultValue(TColumn value);
        IColumnBuilder<TColumn> SetNullable(bool nullable);
        IColumnBuilder<TColumn> SetCheck(Expression<Func<TColumn, bool>> expression);
    }
}

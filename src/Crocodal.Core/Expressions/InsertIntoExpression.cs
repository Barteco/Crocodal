namespace Crocodal.Core.Expressions
{
    public class InsertIntoExpression : ISqlExpression
    {
        public ITableIdentifierExpression Table { get; }
        public ColumnListExpression Columns { get; }
        public InsertValuesListExpression Values { get; }

        public InsertIntoExpression(ITableIdentifierExpression table, ColumnListExpression columns, InsertValuesListExpression values)
        {
            Table = table;
            Columns = columns;
            Values = values;
        }
    }
}

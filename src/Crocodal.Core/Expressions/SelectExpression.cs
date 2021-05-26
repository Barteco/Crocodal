namespace Crocodal.Core.Expressions
{
    public class SelectExpression : IQueryExpression
    {
        public CteListExpression With { get; }
        public ColumnListExpression Columns { get; }
        public FromListExpression From { get; }
        public BinaryExpression Condition { get; }

        public SelectExpression(ColumnListExpression columns)
        {
            Columns = columns;
        }

        public SelectExpression(ColumnListExpression columns, FromListExpression from)
        {
            Columns = columns;
            From = from;
        }
    }
}

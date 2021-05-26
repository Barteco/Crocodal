namespace Crocodal.Core.Expressions
{
    public class UpdateExpression : ISqlExpression
    {
        public ITableIdentifierExpression Table { get; }
        public UpdateSetValuesListExpression Values { get; }
        public BinaryExpression Condition { get; }

        public UpdateExpression(ITableIdentifierExpression table, UpdateSetValuesListExpression values)
        {
            Table = table;
            Values = values;
        }

        public UpdateExpression(ITableIdentifierExpression table, UpdateSetValuesListExpression values, BinaryExpression condition)
        {
            Table = table;
            Values = values;
            Condition = condition;
        }
    }
}

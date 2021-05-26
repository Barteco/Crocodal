namespace Crocodal.Core.Expressions
{
    public class InsertIntoSelectExpression : ISqlExpression
    {
        public ITableIdentifierExpression Table { get; }
        public IQueryExpression Select { get; }

        public InsertIntoSelectExpression(ITableIdentifierExpression table, IQueryExpression select)
        {
            Table = table;
            Select = select;
        }
    }
}

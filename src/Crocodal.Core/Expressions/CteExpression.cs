namespace Crocodal.Core.Expressions
{
    public class CteExpression : ISqlExpression
    {
        public IdentifierExpression Identifier { get; set; }
        public ColumnListExpression Columns { get; set; }
        public IQueryExpression Definition { get; set; }
    }
}

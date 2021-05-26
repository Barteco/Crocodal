namespace Crocodal.Core.Expressions
{
    public class ColumnListExpression : ISqlExpression
    {
        public ListExpression Children { get; }

        public ColumnListExpression(params ISqlExpression[] children)
        {
            Children = new ListExpression(children);
        }
    }
}

namespace Crocodal.Core.Expressions
{
    public class InsertValuesListExpression : ISqlExpression
    {
        public ListExpression[] Children { get; }

        public InsertValuesListExpression(params ListExpression[] children)
        {
            Children = children;
        }
    }
}

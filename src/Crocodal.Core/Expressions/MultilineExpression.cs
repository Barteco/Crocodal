namespace Crocodal.Core.Expressions
{
    public class MultilineExpression : ISqlExpression
    {
        public ISqlExpression[] Children { get; set; }
    }
}

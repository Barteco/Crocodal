using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class WithStatement : SqlExpression
    {
        public EntityName Name { get; set; }
        public EntityColumnName[] Columns { get; set; }
        public SqlExpression Body { get; set; }
    }
}

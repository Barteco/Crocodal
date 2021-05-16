using Crocodal.Core.Statements.Abstract;

namespace Crocodal.Core.Statements
{
    public class ComplexStatement : ExecutableStatement
    {
        public ExecutableStatement[] Statements { get; set; }
    }
}
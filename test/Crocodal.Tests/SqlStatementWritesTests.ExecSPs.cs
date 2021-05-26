using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_ExecuteStoredProcedure()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var name = new ComplexIdentifierExpression(x, y);
            var literal1 = new IntLiteralExpression(1);
            var literal2 = new IntLiteralExpression(2);
            var parameters = new ListExpression(literal1, literal2);
            var expression = new ExecuteStoredProcedureExpression(name, parameters);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("EXEC [x].[y] 1, 2", sql);
        }
    }
}

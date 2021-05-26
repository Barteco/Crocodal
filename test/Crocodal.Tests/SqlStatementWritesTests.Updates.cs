using Crocodal.Core.Expressions;
using Xunit;
using Operator = System.Linq.Expressions.ExpressionType;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_Update()
        {
            // Arrange
            var table = new IdentifierExpression("table");
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var literal1 = new IntLiteralExpression(1);
            var literal2 = new IntLiteralExpression(2);
            var set1 = new BinaryAssignmentExpression(x, literal1);
            var set2 = new BinaryAssignmentExpression(y, literal2);
            var values = new UpdateSetValuesListExpression(set1, set2);
            var expression = new UpdateExpression(table, values);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"UPDATE [table]{NewLine}SET [x] = 1, [y] = 2", sql);
        }

        [Fact]
        public void Writes_Update_WithCondition()
        {
            // Arrange
            var table = new IdentifierExpression("table");
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var literal1 = new IntLiteralExpression(1);
            var literal2 = new IntLiteralExpression(2);
            var set1 = new BinaryAssignmentExpression(x, literal1);
            var set2 = new BinaryAssignmentExpression(y, literal2);
            var values = new UpdateSetValuesListExpression(set1, set2);
            var condition = new BinaryExpression(literal1, literal1, Operator.Equal);
            var expression = new UpdateExpression(table, values, condition);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"UPDATE [table]{NewLine}SET [x] = 1, [y] = 2{NewLine}WHERE 1 = 1", sql);
        }
    }
}

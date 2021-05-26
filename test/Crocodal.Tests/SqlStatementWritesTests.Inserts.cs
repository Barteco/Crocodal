using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_InsertInto()
        {
            // Arrange
            var table = new IdentifierExpression("table");
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var columns = new ColumnListExpression(x, y);
            var literal1 = new IntLiteralExpression(1);
            var literal2 = new IntLiteralExpression(2);
            var literal3 = new IntLiteralExpression(3);
            var literal4 = new IntLiteralExpression(4);
            var values1 = new ListExpression(literal1, literal2);
            var values2 = new ListExpression(literal3, literal4);
            var values = new InsertValuesListExpression(values1, values2);
            var expression = new InsertIntoExpression(table, columns, values);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"INSERT INTO [table] ([x], [y]){NewLine}VALUES (1, 2),{NewLineTab}(3, 4)", sql);
        }

        [Fact]
        public void Writes_InsertIntoSelect()
        {
            // Arrange
            var table = new IdentifierExpression("table");

            var literal1 = new IntLiteralExpression(1);
            var literal2 = new IntLiteralExpression(2);
            var columns = new ColumnListExpression(literal1, literal2);
            var select = new SelectExpression(columns);
            var expression = new InsertIntoSelectExpression(table, select);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"INSERT INTO [table]{NewLine}SELECT 1, 2", sql);
        }
    }
}

using Crocodal.Core;
using Crocodal.Core.Statements;
using FluentAssertions;
using Xunit;

namespace Crocodal.Tests.StatementWriter
{
    public class DeclareVariableStatementTests
    {
        private readonly SqlStatmentWriter _statmentWriter = new SqlStatmentWriter();

        [Fact]
        public void ShouldWrite_IntegerVariable()
        {
            // Arrange
            var type = new DatabaseType(typeof(int));
            var expression = new DeclareVariableStatement(null,
                new VariableName("x"),
                type,
                new ScalarValue(type, 5));

            // Act
            var sql = _statmentWriter.Write(expression);

            // Assert
            sql.Should().Be("DECLARE @x INT = 5;");
        }
    }
}

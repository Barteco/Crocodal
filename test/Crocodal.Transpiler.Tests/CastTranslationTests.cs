using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class CastTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public CastTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_AsCast()
        {
            // Arrange
            var unit = _fixture.Compile("5 as object");

            // Act
            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var convertExpression = ExpressionAssert.AsConvert(expression, typeof(object));
            ExpressionAssert.Constant(convertExpression.Operand, 5);
        }

        [Fact]
        public void ShouldParse_IsCheck()
        {
            // Arrange
            var unit = _fixture.Compile("5 is object");

            // Act
            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryTypeCheck = ExpressionAssert.AsBinaryTypeCheck(expression, typeof(object));
            ExpressionAssert.Constant(binaryTypeCheck.Expression, 5);
        }

        [Fact]
        public void ShouldParse_DirectCast()
        {
            // Arrange
            var unit = _fixture.Compile("(int)5.5");

            // Act
            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var convertExpression = ExpressionAssert.AsConvertChecked(expression, typeof(int));
            ExpressionAssert.Constant(convertExpression.Operand, 5.5);
        }
    }
}

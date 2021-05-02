using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class LiteralTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public LiteralTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("null", null)]
        [InlineData("5", 5)]
        [InlineData("5.5f", 5.5f)]
        [InlineData("'x'", 'x')]
        [InlineData("\"test\"", "test")]
        public void ShouldParse_LiteralExpression(string script, object expectedLiteral)
        {
            // Arrange
            var unit = _fixture.Compile(script);

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Constant(expression, expectedLiteral);
        }

        [Theory]
        [InlineData("5.5M", 5.5)]
        public void ShouldParse_DecimalLiteralExpression(string script, object expectedLiteral)
        {
            var expectedDecimal = Convert.ToDecimal(expectedLiteral);
            // Arrange
            var unit = _fixture.Compile(script);

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Constant(expression, expectedDecimal);
        }
    }
}

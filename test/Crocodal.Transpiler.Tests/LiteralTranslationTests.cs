using Crocodal.Transpiler.Tests.Core;
using System;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class LiteralTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

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
            var unit = Compiler.Compile(script);

            var expression = _translator.Translate(unit);

            ExpressionAssert.Constant(expression, expectedLiteral);
        }

        [Theory]
        [InlineData("5.5M", 5.5)]
        public void ShouldParse_DecimalLiteralExpression(string script, object expectedLiteral)
        {
            var expectedDecimal = Convert.ToDecimal(expectedLiteral);
            var unit = Compiler.Compile(script);

            var expression = _translator.Translate(unit);

            ExpressionAssert.Constant(expression, expectedDecimal);
        }
    }
}

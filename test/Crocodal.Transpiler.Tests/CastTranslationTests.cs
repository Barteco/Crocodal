using Crocodal.Transpiler.Tests.Core;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class CastTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_AsCast()
        {
            var unit = Compiler.Compile("5 as object");

            var expression = _translator.Translate(unit);

            var convertExpression = ExpressionAssert.AsConvert(expression, typeof(object));
            ExpressionAssert.Constant(convertExpression.Operand, 5);
        }

        [Fact]
        public void ShouldParse_IsCheck()
        {
            var unit = Compiler.Compile("5 is object");

            var expression = _translator.Translate(unit);

            var binaryTypeCheck = ExpressionAssert.AsBinaryTypeCheck(expression, typeof(object));
            ExpressionAssert.Constant(binaryTypeCheck.Expression, 5);
        }

        [Fact]
        public void ShouldParse_DirectCast()
        {
            var unit = Compiler.Compile("(int)5.5");

            var expression = _translator.Translate(unit);

            var convertExpression = ExpressionAssert.AsConvertChecked(expression, typeof(int));
            ExpressionAssert.Constant(convertExpression.Operand, 5.5);
        }
    }
}

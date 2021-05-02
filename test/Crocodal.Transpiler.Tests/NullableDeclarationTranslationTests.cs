using Crocodal.Transpiler.Tests.Core;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class NullableDeclarationTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_NullableTypeDeclaration()
        {
            var unit = Compiler.Compile("int? x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(int?), "x");
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration_WithQualifiedName()
        {
            var unit = Compiler.Compile("Nullable<int> x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(int?), "x");
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration_WithInitializer()
        {
            var unit = Compiler.Compile("int? x = 5;");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int?), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration_WithInitializer_WithQualifiedName()
        {
            var unit = Compiler.Compile("Nullable<int> x = 5;");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int?), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }
    }
}

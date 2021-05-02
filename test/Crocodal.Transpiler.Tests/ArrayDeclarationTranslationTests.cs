using Crocodal.Transpiler.Tests.Core;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class ArrayDeclarationTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType()
        {
            var unit = Compiler.Compile("int[] x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(int[]), "x");
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithBounds()
        {
            var unit = Compiler.Compile("int[] x = new int[3];");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayBounds(binaryExpression.Right, typeof(int[]));
            ExpressionAssert.Constant(newArray.Expressions[0], 3);
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithInitializer()
        {
            var unit = Compiler.Compile("int[] x = new int[] { 1, 2, 3 };");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayInit(binaryExpression.Right, typeof(int[]), 3);
            ExpressionAssert.ArrayOfConstants(newArray.Expressions, 1, 2, 3);
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithBounds_WithInitializer()
        {
            var unit = Compiler.Compile("int[] x = new int[3] { 1, 2, 3 };");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayInit(binaryExpression.Right, typeof(int[]), 3);
            ExpressionAssert.ArrayOfConstants(newArray.Expressions, 1, 2, 3);
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithArrayInitializer()
        {
            var unit = Compiler.Compile("int[] x = { 1, 2, 3 };");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayInit(binaryExpression.Right, typeof(int[]), 3);
            ExpressionAssert.ArrayOfConstants(newArray.Expressions, 1, 2, 3);
        }
    }
}

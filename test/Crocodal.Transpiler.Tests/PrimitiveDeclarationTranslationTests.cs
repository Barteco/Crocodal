using Crocodal.Transpiler.Tests.Core;
using System.Linq;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class PrimitiveDeclarationTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_PrimitiveTypeDeclaration()
        {
            var unit = Compiler.Compile("int x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(int), "x");
        }

        [Fact]
        public void ShouldParse_PrimitiveTypeDeclaration_WithInitializer()
        {
            var unit = Compiler.Compile("int x = 5;");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }

        [Fact]
        public void ShouldParse_CombinedDeclarations()
        {
            var unit = Compiler.Compile("int x, y;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression).ToArray();
            Assert.Equal(2, expressions.Length);
            ExpressionAssert.Declaration(expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(expressions[1], typeof(int), "y");
        }

        [Fact]
        public void ShouldParse_CombinedDeclarations_WithInitializers()
        {
            var unit = Compiler.Compile("int x = 5, y = 6;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression).ToArray();
            Assert.Equal(2, expressions.Length);
            var firstBinaryExpression = ExpressionAssert.AsBinaryAssign(expressions[0]);
            var secondBinaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            ExpressionAssert.Declaration(firstBinaryExpression.Left, typeof(int), "x");
            ExpressionAssert.Constant(firstBinaryExpression.Right, 5);
            ExpressionAssert.Declaration(secondBinaryExpression.Left, typeof(int), "y");
            ExpressionAssert.Constant(secondBinaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_VarDeclaration_WithInitializer()
        {
            var unit = Compiler.Compile("var x = 5;");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }

        [Fact]
        public void ShouldParse_VarDeclaration_Passed_To_AnotherStatement_WithCorrectType()
        {
            var unit = Compiler.Compile("var x = 1; var y = x;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int), "y");
            ExpressionAssert.Parameter(binaryExpression.Right, typeof(int), "x");
        }
    }
}

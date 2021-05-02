using Crocodal.Transpiler.Tests.Core;
using System;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class TupleDeclarationTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_TupleDeclaration_Explicit_WithInitializer()
        {
            var unit = Compiler.Compile("Tuple<int, int> x = (5, 6);");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(Tuple<int, int>), "x");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_AsVar_WithInitializer()
        {
            var unit = Compiler.Compile("var x = (5, 6);");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(Tuple<int,int>), "x");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithExplicitTypesInside_WithInitializer()
        {
            var unit = Compiler.Compile("(int x, int y) = (5, 6);");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithVarsInside_WithInitializer()
        {
            var unit = Compiler.Compile("(var x, var y) = (5, 6);");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithExplicitTypeOutside_WithInitializer()
        {
            var unit = Compiler.Compile("int (x, y) = (5, 6);");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithVarOutside_WithInitializer()
        {
            var unit = Compiler.Compile("var (x, y) = (5, 6);");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }
    }
}

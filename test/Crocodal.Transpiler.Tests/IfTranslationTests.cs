using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class IfTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public IfTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_If_WithEmptyBody()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Empty(trueExpressions);
            ExpressionAssert.Default(ifStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_If_WithBody()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) { var x = true; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            ExpressionAssert.Default(ifStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_If_WithEmptyElse()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) { var x = true; } else { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var falseExpressions = ExpressionAssert.AsBlock(ifStatement.IfFalse);
            Assert.Empty(falseExpressions);
        }

        [Fact]
        public void ShouldParse_If_WithElse()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) { var x = true; } else { var y = false; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var falseExpressions = ExpressionAssert.AsBlock(ifStatement.IfFalse);
            Assert.Single(falseExpressions);
        }

        [Fact]
        public void ShouldParse_If_WithElseIf()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) { var x = true; } else if (false) { var y = false; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var elseIfStatement = ExpressionAssert.AsConditional(ifStatement.IfFalse);
            ExpressionAssert.Constant(elseIfStatement.Test, false);
            var elseTrueExpressions = ExpressionAssert.AsBlock(elseIfStatement.IfTrue);
            Assert.Single(elseTrueExpressions);
            ExpressionAssert.Default(elseIfStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_If_WithElseIf_WithElse()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) { var x = true; } else if (false) { var y = false; } else { var z = false; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var elseIfStatement = ExpressionAssert.AsConditional(ifStatement.IfFalse);
            ExpressionAssert.Constant(elseIfStatement.Test, false);
            var elseTrueExpressions = ExpressionAssert.AsBlock(elseIfStatement.IfTrue);
            Assert.Single(elseTrueExpressions);
            var elseFalseExpressions = ExpressionAssert.AsBlock(elseIfStatement.IfFalse);
            Assert.Single(elseFalseExpressions);
        }

        [Fact]
        public void ShouldParse_If_WithElse_WithoutBraces()
        {
            // Arrange
            var unit = _fixture.Compile("if(true) var x = true; else var y = false;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            ExpressionAssert.AsBinaryAssign(ifStatement.IfTrue);
            ExpressionAssert.AsBinaryAssign(ifStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_TernaryConditionalStatement()
        {
            // Arrange
            var unit = _fixture.Compile("var x = true ? true : false;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var ternaryStatement = ExpressionAssert.AsConditional(binaryExpression.Right);
            ExpressionAssert.Constant(ternaryStatement.Test, true);
            ExpressionAssert.Constant(ternaryStatement.IfTrue, true);
            ExpressionAssert.Constant(ternaryStatement.IfFalse, false);
        }
    }
}

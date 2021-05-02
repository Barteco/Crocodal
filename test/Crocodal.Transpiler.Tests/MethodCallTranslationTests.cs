using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class MethodCallTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public MethodCallTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_InstanceMethodCall()
        {
            // Arrange
            var unit = _fixture.Compile("int x = 5; x.ToString();");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var methodCall = ExpressionAssert.AsMethodCall(expressions[1]);
            ExpressionAssert.Parameter(methodCall.Object, typeof(int), "x");
            Assert.Equal("ToString", methodCall.Method.Name);
            Assert.Equal(typeof(int), methodCall.Method.DeclaringType);
            Assert.Empty(methodCall.Arguments);
        }

        [Fact]
        public void ShouldParse_InstanceMethodCall_WithArguments()
        {
            // Arrange
            var unit = _fixture.Compile("int x = 5; x.Equals(1);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var methodCall = ExpressionAssert.AsMethodCall(expressions[1]);
            ExpressionAssert.Parameter(methodCall.Object, typeof(int), "x");
            Assert.Equal("Equals", methodCall.Method.Name);
            Assert.Equal(typeof(int), methodCall.Method.DeclaringType);
            Assert.Single(methodCall.Arguments);
            ExpressionAssert.Constant(methodCall.Arguments[0], 1);
        }

        [Fact]
        public void ShouldParse_ChainedMethodCall()
        {
            // Arrange
            var unit = _fixture.Compile("int x = 5; x.ToString().ToLower();");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var methodCall = ExpressionAssert.AsMethodCall(expressions[1]);
            var chainedMethodCall = ExpressionAssert.AsMethodCall(methodCall.Object);
            Assert.Equal("ToString", chainedMethodCall.Method.Name);
            Assert.Equal(typeof(int), chainedMethodCall.Method.DeclaringType);
            Assert.Empty(chainedMethodCall.Arguments);
            Assert.Equal("ToLower", methodCall.Method.Name);
            Assert.Equal(typeof(string), methodCall.Method.DeclaringType);
            Assert.Empty(methodCall.Arguments);
        }

        [Fact]
        public void ShouldParse_StaticMethodCall()
        {
            // Arrange
            var unit = _fixture.Compile(@"DateTime.Parse("""");");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var methodCall = ExpressionAssert.AsMethodCall(expression);
            Assert.Null(methodCall.Object);
            Assert.Equal("Parse", methodCall.Method.Name);
            Assert.Equal(typeof(DateTime), methodCall.Method.DeclaringType);
            Assert.True(methodCall.Method.IsStatic);
            Assert.Single(methodCall.Arguments);
            ExpressionAssert.Constant(methodCall.Arguments[0], "");
        }
    }
}

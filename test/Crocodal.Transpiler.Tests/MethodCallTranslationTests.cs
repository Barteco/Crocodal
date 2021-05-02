using Crocodal.Transpiler.Tests.Core;
using System;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class MethodCallTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_InstanceMethodCall()
        {
            var unit = Compiler.Compile("int x = 5; x.ToString();");

            var expression = _translator.Translate(unit);

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
            var unit = Compiler.Compile("int x = 5; x.Equals(1);");

            var expression = _translator.Translate(unit);

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
            var unit = Compiler.Compile("int x = 5; x.ToString().ToLower();");

            var expression = _translator.Translate(unit);

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
            var unit = Compiler.Compile(@"DateTime.Parse("""");");

            var expression = _translator.Translate(unit);

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

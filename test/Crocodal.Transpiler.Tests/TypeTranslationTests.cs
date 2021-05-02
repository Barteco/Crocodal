using Crocodal.Transpiler.Tests.Core;
using System;
using System.Collections.Generic;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class TypeTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        public static IEnumerable<object[]> TypeDeclarationData => new List<object[]>
        {
            new object[] { "object x;", typeof(object), "x" },
            new object[] { "char x;", typeof(char), "x" },
            new object[] { "string x;", typeof(string), "x" },
            new object[] { "bool x;", typeof(bool), "x" },
            new object[] { "byte x;", typeof(byte), "x" },
            new object[] { "sbyte x;", typeof(sbyte), "x" },
            new object[] { "short x;", typeof(short), "x" },
            new object[] { "ushort x;", typeof(ushort), "x" },
            new object[] { "int x;", typeof(int), "x" },
            new object[] { "uint x;", typeof(uint), "x" },
            new object[] { "long x;", typeof(long), "x" },
            new object[] { "ulong x;", typeof(ulong), "x" },
            new object[] { "float x;", typeof(float), "x" },
            new object[] { "double x;", typeof(double), "x" },
            new object[] { "decimal x;", typeof(decimal), "x" }
        };

        public static IEnumerable<object[]> ArrayTypeDeclarationData => new List<object[]>
        {
            new object[] { "string[] x;", typeof(string[]), "x" }
        };

        public static IEnumerable<object[]> GenericTypeDeclarationData => new List<object[]>
        {
            new object[] { "List<string> x;", typeof(List<string>), "x" },
            new object[] { "List<List<string>> x;", typeof(List<List<string>>), "x" },
            new object[] { "Dictionary<string, string> x;", typeof(Dictionary<string, string>), "x" }
        };

        public static IEnumerable<object[]> QualifiedNameTypeDeclarationData => new List<object[]>
        {
            new object[] { "String x;", typeof(string), "x" },
            new object[] { "System.String x;", typeof(string), "x" },
            new object[] { "System.Collections.Generic.List<string> x;", typeof(List<string>), "x" },
            new object[] { "System.Collections.Generic.List<System.String> x;", typeof(List<string>), "x" },
        };

        [Theory]
        [MemberData(nameof(TypeDeclarationData))]
        [MemberData(nameof(GenericTypeDeclarationData))]
        [MemberData(nameof(QualifiedNameTypeDeclarationData))]
        [MemberData(nameof(ArrayTypeDeclarationData))]
        public void ShouldParse_Type(string script, Type expectedType, string expectedVarName)
        {
            var unit = Compiler.Compile(script);

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, expectedType, expectedVarName);
        }
    }
}

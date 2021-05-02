using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Crocodal.Transpiler.Tests.Core
{
    public static class Compiler
    {
        public static CompilationUnitSyntax Compile(string script)
        {
            return CSharpSyntaxTree.ParseText(script, new CSharpParseOptions(kind: SourceCodeKind.Script)).GetRoot() as CompilationUnitSyntax;
        }
    }
}

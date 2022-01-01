using Crocodal.Core;
using System;
using Xunit.Abstractions;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        private readonly SqlStatmentWriter _writer = new();
        private readonly ITestOutputHelper _output;

        private const char Tab = '\t';
        private static readonly string NewLine = Environment.NewLine;
        private static readonly string NewLineTab = NewLine + Tab;

        public SqlStatementWritesTests(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}

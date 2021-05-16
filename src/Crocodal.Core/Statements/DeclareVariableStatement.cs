using Crocodal.Core.Statements.Abstract;
using System;

namespace Crocodal.Core.Statements
{
    public class DeclareVariableStatement : ExecutableStatement<None>
    {
        public VariableName Name { get; }
        public DatabaseType Type { get; }
        public ScalarValue Value { get; }

        public DeclareVariableStatement(IDatabase database) : base(database)
        {
        }
    }

    public class DatabaseType : SqlExpression
    {
        public Type ClrType { get; set; }
        public string OverridenType { get; set; }

        public bool IsStringType { get; set; }
        public int? MaxLength { get; set; }
        public bool? IsUtf8 { get; set; }
    }

    public class ScalarValue : SqlExpression
    {
        public DatabaseType Type { get; set; }
        public object Value { get; set; }
    }

    public class VariableName : SqlExpression
    {
        public string Value { get; set; }
    }

    public class EntityName : SqlExpression
    {
        public string Schema { get; set; }
        public string Name { get; set; }
    }

    public class EntityColumnName : SqlExpression
    {
        public string Parent { get; set; }
        public string Name { get; set; }
    }

    public class ColumnName : SqlExpression
    {
        public string Name { get; set; }
    }
}
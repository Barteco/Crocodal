using Crocodal.Core.Statements.Abstract;
using System;

namespace Crocodal.Core.Statements
{
    public class DeclareVariableStatement : ExecutableStatement<None>
    {
        public VariableName Name { get; }
        public DatabaseType Type { get; }
        public ScalarValue Value { get; }

        public DeclareVariableStatement(IDatabase database, VariableName name, DatabaseType type, ScalarValue value) : base(database)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }

    public class DatabaseType : SqlExpression
    {
        public Type ClrType { get; }
        public string OverridenType { get; }

        public bool IsStringType { get; }
        public int? MaxLength { get; }
        public bool? IsUtf8 { get; }

        public DatabaseType(Type clrType)
        {
            ClrType = clrType;
        }
    }

    public class ScalarValue : SqlExpression
    {
        public DatabaseType Type { get; set; }
        public object Value { get; set; }

        public ScalarValue(DatabaseType type, object value)
        {
            Type = type;
            Value = value;
        }
    }

    public class VariableName : SqlExpression
    {
        public string Value { get; }

        public VariableName(string value)
        {
            Value = value;
        }
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
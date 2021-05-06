using System;
using System.Collections.Generic;

namespace Crocodal.Internal.Statements
{
    internal class InsertStatement : DatabaseStatement<None>, IInsertStatement
    {
        public Type EntityType { get; }
        public List<object> Entities { get; }

        public InsertStatement(IDatabase database, Type entityType, List<object> entities) : base(database)
        {
            EntityType = entityType;
            Entities = entities;
        }
    }
}
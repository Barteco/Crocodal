namespace Crocodal
{
    public class DatabaseOptionsBuilder
    {
        public DatabaseOptionsBuilder GroupSchemas(bool group) { return this; }
        public DatabaseOptionsBuilder GroupFunctions(bool group) { return this; }
        public DatabaseOptionsBuilder GroupStoredProcedures(bool group) { return this; }
        public DatabaseOptionsBuilder GroupViews(bool group) { return this; }
        public DatabaseOptionsBuilder GroupTables(bool group) { return this; }
    }
}
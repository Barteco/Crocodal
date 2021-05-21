namespace Crocodal
{
    public class DatabaseOptions
    {
        public bool GroupSchemas { get; set; } = false;
        public bool GroupFunctions { get; set; } = false;
        public bool GroupStoredProcedures { get; set; } = false;
        public bool GroupViews { get; set; } = false;
        public bool GroupTables { get; set; } = false;
    }
}
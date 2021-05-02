using Crocodal.Samples.Project.Entities;

namespace Crocodal.Samples.Project.Configuration.Tables
{
    class OwnerTable : ITable<Owner>
    {
        public void Configure(ITableBuilder<Owner> builder)
        {
            builder.SetSchema("dbo").SetName("Owners");
        }
    }
}

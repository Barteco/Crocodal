using Crocodal.Samples.Project.Entities;

namespace Crocodal.Samples.Project.Configuration.Tables
{

    class ArchivedProductTable : ITable<ArchivedProduct>
    {
        public void Configure(ITableBuilder<ArchivedProduct> builder)
        {
            builder.SetSchema("dbo").SetName("ArchivedProducts");

            builder.SetForeignKey(e => e.OwnerId, e => e.Owner)
                .References(e => e.Id, e => e.ArchivedProducts)
                .SetOnDelete(DeleteRule.None);
        }
    }
}

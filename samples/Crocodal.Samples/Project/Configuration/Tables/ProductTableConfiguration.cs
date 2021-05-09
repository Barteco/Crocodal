using Crocodal.Samples.Project.Entities;

namespace Crocodal.Samples.Project.Configuration.Tables
{
    class ProductTableConfiguration : ITableConfiguration<Product>
    {
        public void Configure(ITableBuilder<Product> builder)
        {
            builder.SetSchema("dbo").SetName("Products");

            builder.SetForeignKey(e => e.OwnerId, e => e.Owner)
                .References(e => e.Id, e => e.Products)
                .SetOnDelete(DeleteRule.None);
        }
    }
}

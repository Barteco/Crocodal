using Crocodal.Attributes;
using Crocodal.Samples.Project.Entities;
using System.Collections.Generic;

namespace Crocodal.Samples.Project.Configuration.Views
{
    class AvailableProductViewConfiguration : IViewConfiguration<AvailableProduct>
    {
        public void Configure(IViewBuilder<AvailableProduct> builder)
        {
            builder.SetSchema("dbo").SetName("vwAvailableProducts");
        }

        public List<AvailableProduct> Body([Reference] WarehouseDatabase db)
        {
            return db.Products
                .Query()
                .Where(e => e.IsAvailable)
                .Select(e => new AvailableProduct
                {
                    Id = e.Id,
                    Name = e.Name,
                    NetPrice = e.NetPrice,
                })
                .Execute();
        }
    }
}

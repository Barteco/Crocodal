using Crocodal.Attributes;
using Crocodal.Samples.Dtos;
using Crocodal.Samples.Project.Configuration.Functions;
using Crocodal.Samples.Project.Configuration.Procedures;
using Crocodal.Samples.Project.Configuration.Tables;
using Crocodal.Samples.Project.Configuration.Views;
using Crocodal.Samples.Project.Entities;
using System.Collections.Generic;

namespace Crocodal.Samples.Project
{
    class WarehouseDatabase : Database
    {
        // This should code-generated
        public Table<Product> Products => new(this);
        public Table<Product> ArchivedProducts => new(this);
        public View<AvailableProduct> AvailableProducts => new(this);

        [StoredProcedure("dbo.spSearchProducts")]
        public StoredProcedure<List<ProductDto>> SearchProducts(string term)
        {
            return new StoredProcedure<List<ProductDto>>(this, "dbo.spSearchProducts", new
            {
               term
            });
        }

        [Function("dbo.fnCalculatePrice")]
        public Function<decimal> CalculatePrice(decimal price)
        {
            return new Function<decimal>(this, "dbo.fnCalculatePrice", new
            {
                price
            });
        }

        public override void Configure(IDatabaseBuilder builder)
        {
            base.Configure(builder);

            // This should be auto-discovered
            builder.Configure(new ProductTable());
            builder.Configure(new ArchivedProductTable());
            builder.Configure(new AvailableProductView());
            builder.Configure(new SearchProductsProcedure());
            builder.Configure(new CalculatePriceFunction());
        }
    }
}
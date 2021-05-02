﻿using Crocodal.Attributes;
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
        public Table<Product> Products { get; }
        public View<AvailableProduct> AvailableProducts { get; }

        [StoredProcedure("dbo.spSearchProducts")]
        public IExecutableStatement<List<ProductDto>> SearchProducts(string term)
        {
            return new StoredProcedure<List<ProductDto>>(this, "dbo.spSearchProducts", new
            {
               term
            });
        }

        [Function("dbo.fnCalculatePrice")]
        public decimal CalculatePrice(decimal price)
        {
            return new Function<decimal>("dbo.fnCalculatePrice", new
            {
                price
            });
        }

        public override void Configure(IDatabaseBuilder builder)
        {
            base.Configure(builder);

            // This should be auto-discovered
            builder.Configure(new ProductTable());
            builder.Configure(new AvailableProductView());
            builder.Configure(new SearchProductsProcedure());
            builder.Configure(new CalculatePriceFunction());
        }
    }
}
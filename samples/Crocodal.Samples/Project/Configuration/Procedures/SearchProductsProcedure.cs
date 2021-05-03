using Crocodal.Attributes;
using Crocodal.Samples.Dtos;
using System.Collections.Generic;

namespace Crocodal.Samples.Project.Configuration.Procedures
{
    class SearchProductsProcedure : IProcedure
    {
        public void Configure(IProcedureBuilder builder)
        {
            builder.SetSchema("dbo").SetName("spSearchProducts");
        }

        [Body]
        public static List<ProductDto> Body([Reference] WarehouseDatabase db,
            string term)
        {
            return db.AvailableProducts
                .Where(e => e.Name.Contains(term))
                .Select(e => new ProductDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Price = db.CalculatePrice(e.NetPrice)
                })
                .ExecuteQuery();
        }
    }
}

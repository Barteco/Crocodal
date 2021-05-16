using Crocodal.Entities;
using Crocodal.Samples.Dtos;
using Crocodal.Samples.Project.Entities;
using System.Collections.Generic;

namespace Crocodal.Samples.Project
{
    // Generated code
    partial class WarehouseDatabase
    {
        public ITable<Employee> Employees => new Table<Employee>(this);
        public ITable<Owner> Owners => new Table<Owner>(this);
        public ITable<Product> Products => new Table<Product>(this);
        public ITable<ArchivedProduct> ArchivedProducts => new Table<ArchivedProduct>(this);
        public IView<AvailableProduct> AvailableProducts => new View<AvailableProduct>(this);

        public IStoredProcedure<List<ProductDto>> SearchProducts(string term)
        {
            return new StoredProcedure<List<ProductDto>>(this, "[dbo].[spSearchProducts]", new
            {
                term
            });
        }

        public IFunction<decimal> CalculatePrice(decimal price)
        {
            return new Function<decimal>(this, "[dbo].[fnCalculatePrice]", new
            {
                price
            });
        }
    }
}
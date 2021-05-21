using Crocodal.Samples.Project.Configuration.Functions;
using Crocodal.Samples.Project.Configuration.Procedures;
using Crocodal.Samples.Project.Configuration.Tables;
using Crocodal.Samples.Project.Configuration.Views;

namespace Crocodal.Samples.Project
{
    partial class WarehouseDatabase : Database
    {
        protected override void Configure(IDatabaseBuilder builder)
        {
            base.Configure(builder);

            // This should be auto-discovered
            builder.Configure(new ProductTableConfiguration());
            builder.Configure(new OwnerTableConfiguration());
            builder.Configure(new ArchivedProductTableConfiguration());
            builder.Configure(new AvailableProductViewConfiguration());
            builder.Configure(new SearchProductsProcedureConfiguration());
            builder.Configure(new CalculatePriceFunctionConfiguration());
        }
    }
}
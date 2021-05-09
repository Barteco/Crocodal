using Crocodal.Attributes;

namespace Crocodal.Samples.Project.Configuration.Functions
{
    class CalculatePriceFunctionConfiguration : IFunctionConfiguration
    {
        public void Configure(IFunctionBuilder builder)
        {
            builder.SetSchema("dbo").SetName("fnCalculatePrice");
        }

        [Body]
        public static decimal Body(decimal price)
        {
            return price * 1.23m;
        }
    }
}

using Crocodal.Samples.Project.Entities;

namespace Crocodal.Samples.Project.Configuration.Tables
{
    class EmployeeTableConfiguration : ITableConfiguration<Employee>
    {
        public void Configure(ITableBuilder<Employee> builder)
        {
            builder.SetSchema("dbo").SetName("Employees");
        }
    }
}

namespace Crocodal.Samples.Project.Entities
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }
    }
}

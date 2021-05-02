namespace Crocodal.Samples.Project.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public bool IsAvailable { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}

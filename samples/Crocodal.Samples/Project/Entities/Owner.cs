using System.Collections.Generic;

namespace Crocodal.Samples.Project.Entities
{
    class Owner
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Product> Products { get; set; }
    }
}

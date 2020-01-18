using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Potential { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public ICollection<Coordinator> Coordinators { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}

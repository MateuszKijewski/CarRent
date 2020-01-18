using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Worker : Person
    {        
        public Decimal Salary { get; set; }
        public bool IsDeleted { get; set; }

        public int CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; }
        
        public int RegionId { get; set; }
        public Region Region { get; set; }
       
        public Car Car { get; set; }
    }
}

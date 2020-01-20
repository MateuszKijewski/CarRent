using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Worker
    {        
        public Decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; }
        
        public int RegionId { get; set; }
        public Region Region { get; set; }
       
        public Car Car { get; set; }
    }
}

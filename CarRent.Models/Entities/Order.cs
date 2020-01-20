using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Order
    {
        
        public int Id { get; protected set; }
        public DateTime OrderDate { get; set; }
        public int RentalTime { get; set; }
        public string DeliveryPlace { get; set; }
        public Decimal Cost { get; set; }
        public bool IsDeleted { get; set; }

        public ReturnReport ReturnReport { get; set; }
        public RepairReport RepairReport { get; set; }
        
        
        public int? CarId { get; set; }
        public Car? Car { get; set; }

        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }

        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        
    }
}

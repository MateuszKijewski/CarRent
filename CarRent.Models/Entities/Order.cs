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

        /* Parent Relations */
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

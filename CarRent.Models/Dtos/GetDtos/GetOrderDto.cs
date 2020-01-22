using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int RentalTime { get; set; }
        public string DeliveryPlace { get; set; }
        public Decimal Cost { get; set; }
        public bool IsDeleted { get; set; }
        public string CarDescription { get; set; }
        public bool Finished { get; set; }

        public int? CarId { get; set; }
        public int? WorkerId { get; set; }
        public int? ClientId { get; set; }
    }
}

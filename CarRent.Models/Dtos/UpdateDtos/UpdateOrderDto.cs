using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos
{
    public class UpdateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public int RentalTime { get; set; }
        public string DeliveryPlace { get; set; }
        
    }
}

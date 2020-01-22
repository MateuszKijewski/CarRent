using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos
{
    public class UpdateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public int RentalTime { get; set; }
        public string DeliveryPlace { get; set; }

        public bool Validate()
        {

            Regex alphabetic = new Regex("^[a-zA-Z]+$");
            Regex numeric = new Regex("^[0-9]*$");
            Regex mail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if ((!numeric.IsMatch(RentalTime.ToString()))
                || (!alphabetic.IsMatch(DeliveryPlace)))
            {
                return false;
            }

            if (OrderDate > DateTime.Now)
            {
                return false;
            }
            return true;

        }
    }
}

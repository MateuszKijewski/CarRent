using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos.AddDtos
{
    public class UpdateRepairReportDto
    {
        public string Description { get; set; }
        public Decimal Cost { get; set; }
        public int Time { get; set; }

        public bool Validate()
        {

            Regex alphabetic = new Regex("^[a-zA-Z]+$");
            Regex numeric = new Regex("^[0-9]*$");

            if ((!numeric.IsMatch(Cost.ToString()))
                || (!alphabetic.IsMatch(Time.ToString())))
            {
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos.AddDtos
{
    public class UpdateReturnReportDto
    {
        public int DrivenDistance { get; set; }
        public bool IsDamaged { get; set; }
        public DateTime ReturnDate { get; set; }

        public bool Validate()
        {

            Regex numeric = new Regex("^[0-9]*$");

            if (!numeric.IsMatch(DrivenDistance.ToString()))              
            {
                return false;
            }

            if (ReturnDate > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}

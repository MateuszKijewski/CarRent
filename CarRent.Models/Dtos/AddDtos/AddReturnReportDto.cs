using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos.AddDtos
{
    public class AddReturnReportDto
    {
        public int DrivenDistance { get; set; }
        public bool IsDamaged { get; set; }
        public DateTime ReturnDate { get; set; }

        public bool Validate()
        {

            Regex alphabetic = new Regex("^[a-zA-Z]+$");
            Regex numeric = new Regex("^[0-9]*$");
            Regex mail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");

            if (string.IsNullOrEmpty(DrivenDistance.ToString()) || (!numeric.IsMatch(DrivenDistance.ToString())
                || string.IsNullOrEmpty(IsDamaged.ToString())
                || string.IsNullOrEmpty(ReturnDate.ToString())))
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos
{
    public class AddWorkerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Decimal Salary { get; set; }

        public bool Validate()
        {
            Regex alphabetic = new Regex("^[a-zA-Z]+$");
            Regex numeric = new Regex("^[0-9]*$");
            Regex mail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if (string.IsNullOrEmpty(FirstName) || (!alphabetic.IsMatch(FirstName))
                || string.IsNullOrEmpty(LastName) || (!alphabetic.IsMatch(LastName))
                || string.IsNullOrEmpty(PhoneNumber) || (!numeric.IsMatch(PhoneNumber))
                || string.IsNullOrEmpty(Email) || (!mail.IsMatch(Email))
                || string.IsNullOrEmpty(Salary.ToString()) || (!numeric.IsMatch(Salary.ToString())))
            {
                return false;
            }

            return true;
        }
    }
}

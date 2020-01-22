using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos
{
    public class UpdateClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string IdNumber { get; set; }
        public string Pesel { get; set; }

        public bool Validate()
        {

            Regex alphabetic = new Regex("^[a-zA-Z]+$");
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            Regex numeric = new Regex("^[0-9]*$");
            Regex peselPattern = new Regex("[0-9]{4}[0-3]{1}[0-9}{1}[0-9]{5}");
            Regex mail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if ((!alphabetic.IsMatch(FirstName))
                || (!alphabetic.IsMatch(LastName))
                || (!numeric.IsMatch(PhoneNumber))
                || (!mail.IsMatch(Email))
                || (!alphanumeric.IsMatch(DriversLicenseNumber))
                || (!alphanumeric.IsMatch(IdNumber))
                || (!peselPattern.IsMatch(Pesel)))
            {
                return false;
            }
            return true;

        }
    }
}

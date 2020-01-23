using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos
{
    public class AddClientDto
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
            Regex alphabetic = new Regex(@"^[\s\p{L}]+$");
            Regex alphanumeric = new Regex(@"^[\s\p{L}0-9]+$");

            Regex numeric = new Regex("^[0-9]*$");
            Regex peselPattern= new Regex("[0-9]{4}[0-3]{1}[0-9}{1}[0-9]{5}");
            Regex mail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if (string.IsNullOrEmpty(FirstName) || (!alphabetic.IsMatch(FirstName))
                || string.IsNullOrEmpty(LastName) || (!alphabetic.IsMatch(LastName))
                || string.IsNullOrEmpty(PhoneNumber) || (!numeric.IsMatch(PhoneNumber))
                || string.IsNullOrEmpty(Email) || (!mail.IsMatch(Email))
                || string.IsNullOrEmpty(DriversLicenseNumber) || (!alphanumeric.IsMatch(DriversLicenseNumber))
                || string.IsNullOrEmpty(IdNumber) || (!alphanumeric.IsMatch(IdNumber))
                || string.IsNullOrEmpty(Pesel) || (!peselPattern.IsMatch(Pesel)))
            {
                return false;
            }
            return true;

        }
    }
}

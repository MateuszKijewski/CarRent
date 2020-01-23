using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos.AddDtos
{
    public class AddCoordinatorDto
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public bool Validate()
        {

            Regex alphabetic = new Regex(@"^[\s\p{L}]+$");
            Regex numeric = new Regex("^[0-9]*$");
            Regex mail = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if (string.IsNullOrEmpty(Login)
                || string.IsNullOrEmpty(Password)
                || string.IsNullOrEmpty(FirstName) || (!alphabetic.IsMatch(FirstName))
                || string.IsNullOrEmpty(LastName) || (!alphabetic.IsMatch(LastName))
                || string.IsNullOrEmpty(PhoneNumber) || (!numeric.IsMatch(PhoneNumber))
                || string.IsNullOrEmpty(Email) || (!mail.IsMatch(Email)))
            {
                return false;
            }
            return true;

        }
    }
}

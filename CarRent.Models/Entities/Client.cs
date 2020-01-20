using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Client
    {
        public bool IsCompany { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string IdNumber { get; set; }
        public string Pesel { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

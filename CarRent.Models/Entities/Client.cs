using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Client : Person
    {
        public bool IsCompany { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string IdNumber { get; set; }
        public string Pesel { get; set; }
        public bool IsDeleted { get; set; }

    }
}

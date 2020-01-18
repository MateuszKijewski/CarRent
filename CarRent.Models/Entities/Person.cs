using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Person
    {
        public int Id { get; protected set; }
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

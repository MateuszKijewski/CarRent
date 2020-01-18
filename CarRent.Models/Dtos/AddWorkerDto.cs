using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos
{
    public class AddWorkerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Decimal Salary { get; set; }
    }
}

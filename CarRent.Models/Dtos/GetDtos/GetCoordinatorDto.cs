using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos.GetDtos
{
    public class GetCoordinatorDto
    {
        public string Login { get; set; }
        public bool IsDeleted { get; set; }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}

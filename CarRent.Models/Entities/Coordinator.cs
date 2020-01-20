using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Coordinator
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
        /* Child Relations */
        public ICollection<Worker> Workers { get; set; }
    }
}

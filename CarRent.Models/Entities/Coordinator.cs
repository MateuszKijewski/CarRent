using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class Coordinator : Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        /* Child Relations */
        public ICollection<Worker> Workers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Entities
{
    public class ReturnReport
    {
        public int Id { get; protected set; }
        public int DrivenDistance { get; set; }
        public bool IsDamaged { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsDeleted { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

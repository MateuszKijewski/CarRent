using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos.GetDtos
{
    public class GetReturnReportDto
    {
        public int Id { get; set; }
        public int DrivenDistance { get; set; }
        public bool IsDamaged { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsDeleted { get; set; }

        public int OrderId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos.GetDtos
{
    public class GetRepairReportDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal Cost { get; set; }
        public int Time { get; set; }
        public bool IsDeleted { get; set; }

        public int OrderId { get; set; }
    }
}

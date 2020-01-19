using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos.AddDtos
{
    public class AddReturnReportDto
    {
        public int DrivenDistance { get; set; }
        public bool IsDamaged { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}

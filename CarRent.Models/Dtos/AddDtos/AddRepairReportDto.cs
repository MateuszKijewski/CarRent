﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos.AddDtos
{
    public class AddRepairReportDto
    {
        public string Description { get; set; }
        public Decimal Cost { get; set; }
        public int Time { get; set; }

    }
}

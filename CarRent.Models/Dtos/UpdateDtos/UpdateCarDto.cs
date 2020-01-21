using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Models.Dtos
{
    public class UpdateCarDto
    {
        public string LicensePlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public string Color { get; set; }
        public Decimal PricePerDay { get; set; }
        public int Mileage { get; set; }
    }
}

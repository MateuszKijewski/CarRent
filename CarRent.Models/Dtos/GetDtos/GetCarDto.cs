using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Dtos
{
    public class GetCarDto
    {
        public int Id { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public string Color { get; set; }
        public Decimal PricePerDay { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsAway { get; set; }
        public int Mileage { get; set; }
        public bool IsDeleted { get; set; }
        public string WorkerName { get; set; }
        public int WorkerId { get; set; }
        public string Description { get; set; }

    }
}

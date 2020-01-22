using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

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

        public bool Validate()
        {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");

            if ( (!alphanumeric.IsMatch(LicensePlateNumber))
                || (!alphanumeric.IsMatch(Brand))
                || (!alphanumeric.IsMatch(Model))
                || (!alphanumeric.IsMatch(Engine))                
                || (!alphanumeric.IsMatch(Transmission))
                || (!alphanumeric.IsMatch(FuelType))
                || (!alphanumeric.IsMatch(Color)))
            {
                return false;
            }

            int currentYear = DateTime.Now.Year;
            if (Year < (currentYear - 100) || (Year > currentYear))
            {
                return false;
            }

            return true;
        }
    }
}

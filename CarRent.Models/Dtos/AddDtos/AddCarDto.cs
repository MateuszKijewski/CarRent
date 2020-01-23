using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRent.Models.Dtos
{
    public class AddCarDto
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
            Regex alphanumeric = new Regex(@"^[\s\p{L}0-9]+$");

            if (string.IsNullOrEmpty(LicensePlateNumber) || (!alphanumeric.IsMatch(LicensePlateNumber))
                || string.IsNullOrEmpty(Brand) || (!alphanumeric.IsMatch(Brand))
                || string.IsNullOrEmpty(Model) || (!alphanumeric.IsMatch(Model))
                || string.IsNullOrEmpty(Engine) || (!alphanumeric.IsMatch(Engine))
                || string.IsNullOrEmpty(Year.ToString())
                || string.IsNullOrEmpty(Transmission) || (!alphanumeric.IsMatch(Transmission))
                || string.IsNullOrEmpty(FuelType) || (!alphanumeric.IsMatch(FuelType))
                || string.IsNullOrEmpty(Color) || (!alphanumeric.IsMatch(Color))
                || string.IsNullOrEmpty(PricePerDay.ToString())
                || string.IsNullOrEmpty(Mileage.ToString()))
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

using System;
using System.Collections.Generic;
using System.Text;
using CarRent.Models.Dtos;
using CarRent.Models.Entities;

namespace CarRent.Models.Converters
{
    public class CarConverter : ICarConverter
    {
        public Car FromAddCarDtoToCar(AddCarDto addCarDto)
        {
            return new Car
            {
                LicensePlateNumber = addCarDto.LicensePlateNumber,
                Brand = addCarDto.Brand,
                Model = addCarDto.Model,
                Engine = addCarDto.Engine,
                Year = addCarDto.Year,
                Transmission = addCarDto.Transmission,
                FuelType = addCarDto.FuelType,
                Color = addCarDto.Color,
                PricePerDay = addCarDto.PricePerDay,
                Mileage = addCarDto.Mileage
            };
        }

        public GetCarDto FromCarToGetCarDto(Car car)
        {
            return new GetCarDto
            {
                Id = car.Id,
                LicensePlateNumber = car.LicensePlateNumber,
                Brand = car.Brand,
                Model = car.Model,
                Engine = car.Engine,
                Year = car.Year,
                Transmission = car.Transmission,
                FuelType = car.FuelType,
                Color = car.Color,
                PricePerDay = car.PricePerDay,
                IsDamaged = car.IsDamaged,
                IsAway = car.IsAway,
                Mileage = car.Mileage,
                IsDeleted = car.IsDeleted,
                WorkerId = car.WorkerId,
                WorkerName = car.Worker.FullName(),
                Description = car.Description()
            };
        }
    }
}

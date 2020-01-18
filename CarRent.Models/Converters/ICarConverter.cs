using CarRent.Models.Dtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters
{
    public interface ICarConverter
    {
        Car FromAddCarDtoToCar(AddCarDto addCarDto);
        GetCarDto FromCarToGetCarDto(Car car);        
    }
}

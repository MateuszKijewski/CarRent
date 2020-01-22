using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface ICarService
    {
        string AddCar(AddCarDto addCarDto);
        GetCarDto GetCar(int id);
        string DeleteCar(int id);
        IEnumerable<GetCarDto> GetAllCars();
        IEnumerable<GetCarDto> FilterCars(Dictionary<string, string> stringQueries, Dictionary<string, int[]> intQueries, Dictionary<string, bool> isAway);
        GetCarDto UpdateCar(int id, UpdateCarDto updateCarDto);
    }
}

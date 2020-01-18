using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface ICarService
    {
        int AddCar(int regionId, AddCarDto addCarDto);
        GetCarDto GetCar(int id);
        IEnumerable<GetCarDto> GetAllCars();
        IEnumerable<GetCarDto> FilterCars(Dictionary<string, string> stringQueries, Dictionary<string, int[]> intQueries);
    }
}

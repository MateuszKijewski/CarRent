using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRent.Services
{
    public class CarService : ICarService
    {
        private readonly ICarConverter _carConverter;
        private readonly ICarRepository _carRepository;

        public CarService(ICarConverter carConverter, ICarRepository carRepository)
        {
            _carConverter = carConverter;
            _carRepository = carRepository;            
        }

        public int AddCar(AddCarDto addCarDto)
        {
            var car = _carConverter.FromAddCarDtoToCar(addCarDto);
            
            car.IsAway = false;
            car.IsDamaged = false;
            car.IsDeleted = false;

            _carRepository.Add(car);
            return car.Id;
        }

        public GetCarDto GetCar(int id)
        {
            var car = _carRepository.Get(id);
            return _carConverter.FromCarToGetCarDto(car);
        }

        public string DeleteCar(int id)
        {
            _carRepository.Delete(id);
            return $"Car with id {id} was succesfuly deleted";
        }

        public IEnumerable<GetCarDto> GetAllCars()
        {
            return _carRepository.GetAll()
                .Select(c => _carConverter.FromCarToGetCarDto(c));
        }

        public IEnumerable<GetCarDto> FilterCars(Dictionary<string, string> stringQueries, Dictionary<string, int[]> intQueries)
        {
            return _carRepository.Filter(stringQueries, intQueries)
                .Select(c => _carConverter.FromCarToGetCarDto(c));
        }

        public GetCarDto UpdateCar(int id, UpdateCarDto updateCarDto)
        {
            var updateCar = _carConverter.FromUpdateCarDtoToCar(updateCarDto);
            return _carConverter.FromCarToGetCarDto(_carRepository.Update(id, updateCar));
        }

    }
}

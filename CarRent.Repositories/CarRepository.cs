using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.DataAccess;
using CarRent.Models.Entities;

namespace CarRent.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly CarRentDbContext _db;

        public CarRepository(CarRentDbContext db)
        {
            _db = db;
        }

        public Car Get(int id)
        {
            return _db.Cars.First(c => c.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _db.Cars;
        }

        public int Delete(int id)
        {
            var car = _db.Cars.First(c => c.Id == id);
            car.IsDeleted = true;
            _db.SaveChanges();

            return car.Id;
        }

        public int Add(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();

            return car.Id;
        }

        public IEnumerable<Car> Filter(Dictionary<string, string> stringQueries, Dictionary<string, int[]> intQueries)
        {
            List<Car> duplicatesResult = new List<Car>();
                if (intQueries != null)
                {
                    foreach (KeyValuePair<string, int[]> pair in intQueries)
                    {
                        switch (pair.Key)
                        {
                            case "Year":
                                var filteredYear = _db.Cars.Where(c => c.Year >= pair.Value[0]
                                                                && c.Year <= pair.Value[1]);
                                foreach (var item in filteredYear) { duplicatesResult.Add(item); }
                                break;

                            case "PricePerDay":
                                var filteredPPD = _db.Cars.Where(c => c.PricePerDay >= pair.Value[0]
                                                                && c.PricePerDay <= pair.Value[1]);
                                foreach (var item in filteredPPD) { duplicatesResult.Add(item); }
                                break;

                            case "Mileage":
                                var filteredMileage = _db.Cars.Where(c => c.Mileage >= pair.Value[0]
                                                                && c.Mileage <= pair.Value[1]);
                                foreach (var item in filteredMileage) { duplicatesResult.Add(item); }
                                break;
                        }
                    }
                }
                foreach (KeyValuePair<string, string> pair in stringQueries)
                {
                    switch (pair.Key)
                    {
                        case "Brand":
                            var filteredBrands = _db.Cars.Where(c => c.Brand.Contains($"/{pair}/"));
                            foreach (var item in filteredBrands) { duplicatesResult.Add(item); }
                            break;

                        case "Model":
                            var filteredModels = _db.Cars.Where(c => c.Model.Contains($"/{pair}/"));
                            foreach (var item in filteredModels) { duplicatesResult.Add(item); }
                            break;

                        case "Engine":
                            var filteredEngines = _db.Cars.Where(c => c.Engine.Contains($"/{pair}/"));
                            foreach (var item in filteredEngines) { duplicatesResult.Add(item); }
                            break;

                        case "Transmission":
                            var filteredTransmissions = _db.Cars.Where(c => c.Transmission.Contains($"/{pair}/"));
                            foreach (var item in filteredTransmissions) { duplicatesResult.Add(item); }
                            break;

                        case "FuelType":
                            var filteredFuelTypes = _db.Cars.Where(c => c.FuelType.Contains($"/{pair}/"));
                            foreach (var item in filteredFuelTypes) { duplicatesResult.Add(item); }
                            break;

                        case "Color":
                            var filteredColors = _db.Cars.Where(c => c.Color.Contains($"/{pair}/"));
                            foreach (var item in filteredColors) { duplicatesResult.Add(item); }
                            break;

                    }
                }

                List<Car> finalResult = duplicatesResult.Distinct().ToList();
                return finalResult;
        }
    }
}

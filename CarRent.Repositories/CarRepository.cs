using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CarRent.DataAccess;
using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                return _db.Cars.First(c => c.Id == id);
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

        }

        public IEnumerable<Car> GetAll()
        {
            return _db.Cars.Where(c => c.IsDeleted == false);
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

        public IEnumerable<Car> Filter(Dictionary<string, string> stringQueries, Dictionary<string, int[]> intQueries, Dictionary<string, bool> isAway )
        {
            List<Car> duplicatesResult = new List<Car>();
            int queryCount = 0;

            if (isAway != null)
            {
                foreach (KeyValuePair<string, bool> pair in isAway)
                {
                    switch (pair.Key)
                    {
                        case "isAway":
                            var filteredIsAway = _db.Cars.Where(c => c.IsAway == true);

                            break;

                        case "isNotAway":
                            break;
                    }
                }
            }

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
                        var filteredBrands = _db.Cars.Where(c => EF.Functions.Like(c.Brand, $"%{pair.Value}%"));
                        foreach (var item in filteredBrands) { duplicatesResult.Add(item); }
                        break;

                    case "Model":
                        var filteredModels = _db.Cars.Where(c => EF.Functions.Like(c.Model, $"%{pair.Value}%"));
                        foreach (var item in filteredModels) { duplicatesResult.Add(item); }
                        break;

                    case "Engine":
                        var filteredEngines = _db.Cars.Where(c => EF.Functions.Like(c.Engine, $"%{pair.Value}%"));
                        foreach (var item in filteredEngines) { duplicatesResult.Add(item); }
                        break;

                    case "Transmission":
                        var filteredTransmissions = _db.Cars.Where(c => EF.Functions.Like(c.Transmission, $"%{pair.Value}%"));
                        foreach (var item in filteredTransmissions) { duplicatesResult.Add(item); }
                        break;

                    case "FuelType":
                        var filteredFuelTypes = _db.Cars.Where(c => EF.Functions.Like(c.FuelType, $"%{pair.Value}%"));
                        foreach (var item in filteredFuelTypes) { duplicatesResult.Add(item); }
                        break;

                    case "Color":
                        var filteredColors = _db.Cars.Where(c => EF.Functions.Like(c.Color, $"%{pair.Value}%"));
                        foreach (var item in filteredColors) { duplicatesResult.Add(item); }
                        break;

                }
            }
            if (stringQueries == null) { stringQueries = new Dictionary<string, string>(); queryCount += stringQueries.Count; }
            else { queryCount += stringQueries.Count; }
            if (intQueries == null) { intQueries = new Dictionary<string, int[]>(); queryCount += intQueries.Count; }
            else { queryCount += intQueries.Count; }
                       

            List<Car> finalResult = new List<Car>();
            var grouped = duplicatesResult.GroupBy(i => i);
            foreach(var g in grouped)
            {
                if (g.Count() == queryCount)
                {
                    finalResult.Add(g.Key);
                }
            }
            return finalResult.Where(c => c.IsDeleted == false);
        }

        public Car Update(int id, Car car)
        {
            var currentRecord = _db.Cars.First(c => c.Id == id);
            foreach (PropertyInfo property in car.GetType().GetProperties())
            {
                var value = car.GetType().GetProperty(property.Name).GetValue(car, null);
                if (value != null && property.Name.ToLower() != "id")
                {
                    currentRecord.GetType().GetProperty(property.Name).SetValue(currentRecord, value);
                }
            }
            _db.SaveChanges();

            return currentRecord;
        }
    }
}

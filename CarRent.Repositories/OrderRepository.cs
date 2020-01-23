using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CarRent.DataAccess;
using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly CarRentDbContext _db;

        public OrderRepository(CarRentDbContext db)
        {
            _db = db;
        }

        public int Add(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();

            return order.Id;
        }

        public int Delete(int id)
        {
            var order = _db.Orders.First(o => o.Id == id);
            order.IsDeleted = true;
            _db.SaveChanges();

            return order.Id;
        }

        public IEnumerable<Order> Filter(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange, Dictionary<string, bool> finished)
        {
            List<Order> duplicatesResult = new List<Order>();
            int queryCount = 0;

            if (deliveryPlace != null)
            {
                queryCount++;
                var filteredPlaces = _db.Orders.Where(o => EF.Functions.Like(o.DeliveryPlace, $"%{deliveryPlace}%"));
                foreach (var item in filteredPlaces) { duplicatesResult.Add(item); }
            }
            if (rentalTimeRange != null)
            {
                queryCount++;
                var fitleredRentalTime = _db.Orders.Where(o => o.RentalTime >= rentalTimeRange[0]
                                                        && o.RentalTime <= rentalTimeRange[1]);
                foreach(var item in fitleredRentalTime) { duplicatesResult.Add(item); }
            }
            if (costRange != null)
            {
                queryCount++;
                var filteredCost = _db.Orders.Where(o => o.Cost >= costRange[0]
                                                    && o.Cost <= costRange[1]);
                foreach (var item in filteredCost) { duplicatesResult.Add(item); }
            }
            if (dateRange != null)
            {
                queryCount++;
                var filteredDates = _db.Orders.Where(o => o.OrderDate >= dateRange[0]
                                                    && o.OrderDate <= dateRange[1]);
                foreach (var item in filteredDates) { duplicatesResult.Add(item); }
            }
            if (finished != null)
            {
                foreach(KeyValuePair<string, bool> pair in finished)
                {
                    switch (pair.Key)
                    {
                        case "Finished":
                            var filteredFinished = _db.Orders.Where(o => o.Finished == true);
                            foreach(var item in filteredFinished) { duplicatesResult.Add(item); }
                            break;

                        case "notFinished":
                            var filteredNotFinished = _db.Orders.Where(o => o.Finished == false);
                            foreach(var item in filteredNotFinished) { duplicatesResult.Add(item); }
                            break;
                    }
                }
            }
            
            if (finished == null) { finished = new Dictionary<string, bool>(); queryCount += finished.Count; }

            
            List<Order> finalResult = duplicatesResult.Distinct().ToList();
            return finalResult.Where(o => o.IsDeleted == false);

        }

        public Order Get(int id)
        {
            try
            {
                return _db.Orders.First(o => o.Id == id);
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Where(o => o.IsDeleted == false);
        }

        public Order Update(int id, Order order)
        {
            var currentRecord = _db.Orders.First(o => o.Id == id);
            foreach (PropertyInfo property in order.GetType().GetProperties())
            {
                var value = order.GetType().GetProperty(property.Name).GetValue(order, null);
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

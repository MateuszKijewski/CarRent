using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.DataAccess;
using CarRent.Models.Entities;

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

            return order.Id;
        }

        public IEnumerable<Order> Filter(string deliveryPlace, int[] rentalTimeRange, decimal[] costRange, DateTime[] dateRange)
        {
            List<Order> duplicatesResult = new List<Order>();
            if (deliveryPlace != null)
            {
                var filteredPlaces = _db.Orders.Where(o => o.DeliveryPlace.Contains($"/{deliveryPlace}/"));
                foreach(var item in filteredPlaces) { duplicatesResult.Add(item); }
            }
            if (rentalTimeRange != null)
            {
                var fitleredRentalTime = _db.Orders.Where(o => o.RentalTime >= rentalTimeRange[0]
                                                        && o.RentalTime <= rentalTimeRange[1]);
                foreach(var item in fitleredRentalTime) { duplicatesResult.Add(item); }
            }
            if (costRange != null)
            {
                var filteredCost = _db.Orders.Where(o => o.Cost >= costRange[0]
                                                    && o.Cost <= costRange[1]);
                foreach (var item in filteredCost) { duplicatesResult.Add(item); }
            }
            if (dateRange != null)
            {
                var filteredDates = _db.Orders.Where(o => o.OrderDate >= dateRange[0]
                                                    && o.OrderDate <= dateRange[1]);
                foreach (var item in filteredDates) { duplicatesResult.Add(item); }
            }

            List<Order> finalResult = duplicatesResult.Distinct().ToList();
            return finalResult;

        }

        public Order Get(int id)
        {
            return _db.Orders.First(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders;
        }
    }
}

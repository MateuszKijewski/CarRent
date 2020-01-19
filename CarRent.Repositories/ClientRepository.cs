using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.DataAccess;
using CarRent.Models.Entities;

namespace CarRent.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CarRentDbContext _db;

        public ClientRepository(CarRentDbContext db)
        {
            _db = db;
        }

        public int Add(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();

            return client.Id;
        }

        public int Delete(int id)
        {
            var client = _db.Clients.First(c => c.Id == id);
            client.IsDeleted = true;
            _db.SaveChanges();

            return client.Id;
        }

        public IEnumerable<Client> Filter(Dictionary<string, string> stringQueries, Dictionary<string, bool> isCompany)
        {
            List<Client> duplicatesResult = new List<Client>();

            if (isCompany != null)
            {
                foreach(KeyValuePair<string, bool> pair in isCompany)
                {
                    switch (pair.Key)
                    {
                        case "Company":
                            var filteredCompanies = _db.Clients.Where(c => c.IsCompany == true);
                            foreach (var item in filteredCompanies) { duplicatesResult.Add(item); }
                            break;
                        case "notCompany":
                            var filteredNotCompanies = _db.Clients.Where(c => c.IsCompany == false);
                            foreach (var item in filteredNotCompanies) { duplicatesResult.Add(item); }
                            break;
                    }
                }
                
            }

            foreach (KeyValuePair<string, string> pair in stringQueries)
            {
                switch (pair.Key)
                {
                    case "FirstName":
                        var filteredFirstNames = _db.Clients.Where(c => c.FirstName.Contains($"/{pair}/"));
                        foreach (var item in filteredFirstNames) { duplicatesResult.Add(item); }
                        break;

                    case "LastName":
                        var filteredLastNames = _db.Clients.Where(c => c.LastName.Contains($"/{pair}/"));
                        foreach (var item in filteredLastNames) { duplicatesResult.Add(item); }
                        break;

                    case "Phone":
                        var filteredPhoneNumbers = _db.Clients.Where(c => c.PhoneNumber.Contains($"/{pair}/"));
                        foreach (var item in filteredPhoneNumbers) { duplicatesResult.Add(item); }
                        break;

                    case "Email":
                        var filteredEmails = _db.Clients.Where(c => c.Email.Contains($"/{pair}/"));
                        foreach (var item in filteredEmails) { duplicatesResult.Add(item); }
                        break;

                    case "DriversLicenseNumber":
                        var filteredLicenses = _db.Clients.Where(c => c.DriversLicenseNumber.Contains($"/{pair}/"));
                        foreach (var item in filteredLicenses) { duplicatesResult.Add(item); }
                        break;

                    case "IdNumber":
                        var filteredIds = _db.Clients.Where(c => c.IdNumber.Contains($"/{pair}/"));
                        foreach (var item in filteredIds) { duplicatesResult.Add(item); }
                        break;

                    case "Pesel":
                        var filteredPesels = _db.Clients.Where(c => c.Pesel.Contains($"/{pair}/"));
                        foreach (var item in filteredPesels) { duplicatesResult.Add(item); }
                        break;
                }
            }

            List<Client> finalResult = duplicatesResult.Distinct().ToList();
            return finalResult;
        }

        public Client Get(int id)
        {
            return _db.Clients.First(c => c.Id == id);      
        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Clients;
        }
    }
}

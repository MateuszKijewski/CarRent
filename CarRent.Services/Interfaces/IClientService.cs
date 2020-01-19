using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface IClientService
    {
        int AddClient(AddClientDto addClientDto);
        IEnumerable<GetClientDto> FilterClients(Dictionary<string, string> pairs, Dictionary<string, bool> isCompany);
        IEnumerable<GetClientDto> GetAllClients();
        GetClientDto GetClient(int id);
    }
}

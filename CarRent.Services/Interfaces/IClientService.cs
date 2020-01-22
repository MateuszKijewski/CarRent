using CarRent.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Services
{
    public interface IClientService
    {
        string AddClient(AddClientDto addClientDto);
        string DeleteClient(int id);
        IEnumerable<GetClientDto> FilterClients(Dictionary<string, string> pairs, Dictionary<string, bool> company);
        IEnumerable<GetClientDto> GetAllClients();
        GetClientDto GetClient(int id);
        public GetClientDto UpdateClient(int id, UpdateClientDto updateClientDto);
    }
}

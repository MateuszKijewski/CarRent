using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;

namespace CarRent.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientConverter _clientConverter;
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientConverter clientConverter, IClientRepository clientRepository)
        {
            _clientConverter = clientConverter;
            _clientRepository = clientRepository;
        }

        public int AddClient(AddClientDto addClientDto)
        {
            var client = _clientConverter.AddClientDtoToClient(addClientDto);
            client.IsDeleted = false;
            return _clientRepository.Add(client);
        }

        public IEnumerable<GetClientDto> FilterClients(Dictionary<string, string> pairs, Dictionary<string, bool> isCompany)
        {
            return _clientRepository.Filter(pairs, isCompany)
                .Select(c => _clientConverter.ClientToGetClientDto(c));

        }

        public IEnumerable<GetClientDto> GetAllClients()
        {
            return _clientRepository.GetAll()
                .Select(c => _clientConverter.ClientToGetClientDto(c));
        }

        public GetClientDto GetClient(int id)
        {
            return _clientConverter.ClientToGetClientDto(_clientRepository.Get(id));
        }

        public string DeleteClient(int id)
        {
            _clientRepository.Delete(id);
            return $"Client with id {id} was succesfuly deleted";
        }

        public GetClientDto UpdateClient(int id, UpdateClientDto updateClientDto)
        {
            var updateClient = _clientConverter.UpdateClientDtoToClient(updateClientDto);
            return _clientConverter.ClientToGetClientDto(_clientRepository.Update(id, updateClient));
        }
    }
}

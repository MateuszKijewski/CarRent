using CarRent.Models.Dtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters
{
    public interface IClientConverter
    {
        GetClientDto ClientToGetClientDto(Client client);
        Client AddClientDtoToClient(AddClientDto addClientDto);
        Client UpdateClientDtoToClient(UpdateClientDto updateClientDto);
    }
}

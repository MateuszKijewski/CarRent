using CarRent.Models.Dtos;
using CarRent.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Models.Converters
{
    public interface IClientConverter
    {
        GetClientDto ClientToGetClienToDto(Client client);
        Client AddClientDtoToClient(AddClientDto addClientDto);
    }
}

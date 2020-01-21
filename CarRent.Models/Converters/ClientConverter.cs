using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using CarRent.Models.Dtos;
using CarRent.Models.Entities;

namespace CarRent.Models.Converters
{
    public class ClientConverter : IClientConverter
    {
        public Client AddClientDtoToClient(AddClientDto addClientDto)
        {
            return new Client
            {
                FirstName = addClientDto.FirstName,
                LastName = addClientDto.LastName,
                PhoneNumber = addClientDto.PhoneNumber,
                Email = addClientDto.Email,
                DriversLicenseNumber = addClientDto.DriversLicenseNumber,
                IdNumber = addClientDto.IdNumber,
                Pesel = addClientDto.Pesel
            };
        }

        public GetClientDto ClientToGetClientDto(Client client)
        {
            return new GetClientDto
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                DriversLicenseNumber = client.DriversLicenseNumber,
                IdNumber = client.IdNumber,
                Pesel = client.Pesel,
                IsDeleted = client.IsDeleted,
                fullName = client.FullName(),
                description = $"{client.FullName()}, {client.PhoneNumber}, {client.Email}, {client.Pesel}"


        };
        }

        public Client UpdateClientDtoToClient(UpdateClientDto updateClientDto)
        {
            return new Client
            {
                FirstName = updateClientDto.FirstName,
                LastName = updateClientDto.LastName,
                PhoneNumber = updateClientDto.PhoneNumber,
                Email = updateClientDto.Email,
                DriversLicenseNumber = updateClientDto.DriversLicenseNumber,
                IdNumber = updateClientDto.IdNumber,
                Pesel = updateClientDto.Pesel
            };
        }
    }
}

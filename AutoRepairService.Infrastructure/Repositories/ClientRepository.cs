using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
using AutoRepairService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AutoRepairServiceDbContext _context;

        public ClientRepository(AutoRepairServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _context.Clients
                .Select(s => new ClientDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Patronomic = s.Patronymic,
                    Birthday = s.Birthday.Value.Date,
                    RegistrationDate = s.RegistrationDate,
                    Email = Email.Create(s.Email).Value,
                    Phone = Phone.Create(s.Phone).Value,
                    PhotoPath = s.PhotoPath,
                }).ToListAsync();

            if (clients is null)
                return Enumerable.Empty<ClientDto>();
            else
                return clients;
        }

        public async Task<Maybe<ClientDto>> GetClientByIdAsync(int id)
        {
            var client = await _context.Clients
                .Select(s => new ClientDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Patronomic = s.Patronymic,
                    Birthday = s.Birthday.Value.Date,
                    RegistrationDate = s.RegistrationDate,
                    Email = Email.Create(s.Email).Value,
                    Phone = Phone.Create(s.Phone).Value,
                    PhotoPath = s.PhotoPath,
                }).SingleOrDefaultAsync(x=> x.Id == id);

            if (client is null)
                return Maybe<ClientDto>.From(client);
            else 
                return client;
        }

        public async Task<IEnumerable<ClientDto>> GetClientOffsetAsync(int size, int cursor)
        {
            var query = _context.Clients
                .Select(s => new ClientDto
                {
                   Id = s.Id,
                   FirstName = s.FirstName,
                   LastName = s.LastName,
                   Patronomic = s.Patronymic,
                   Birthday = s.Birthday.Value.Date,
                   RegistrationDate = s.RegistrationDate,
                   Email = Email.Create(s.Email).Value,
                   Phone = Phone.Create(s.Phone).Value,
                   PhotoPath = s.PhotoPath,
                });

             var pagedClients = await query
                .Where(s=> s.Id < cursor)
                .Take(size)
                .ToListAsync();

            return pagedClients;
        }
    }
}

using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
using AutoRepairService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var clients = await _context.Clients.ToListAsync();

            if (clients is null)
                return Enumerable.Empty<Client>();
            else
                return clients;
        }

        public  IEnumerable<Client> GetAll()
        {
            var clients = _context.Clients.ToList();

            if (clients is null)
                return Enumerable.Empty<Client>();
            else
                return clients;
        }

        public async Task<Maybe<Client>> GetClientByIdAsync(int id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(x=> x.Id == id);

            if (client is null)
                return Maybe<Client>.From(client);
            else 
                return client;
        }

        public async Task<IEnumerable<Client>> GetNextClientOffsetAsync(int size,int cursor)
        {


             var pagedClients = await _context.Clients
                .Where(s => s.Id > cursor)
                .Take(size)
                .Include(c=> c.GenderCodeNavigation)
                .Include(c=> c.Tags)
                .ToListAsync();

                return pagedClients;
        }
        public async Task<IEnumerable<Client>> GetPreviosClientOffsetAsync(int size,int cursor)
        {

            var pagedClients = await _context.Clients
               .Where (s => s.Id <= cursor - size && s.Id > cursor-(2*size))
               .Include(c => c.GenderCodeNavigation)
               .Include(c => c.Tags)
               .ToListAsync();

            return pagedClients;
        }

        public Task<int> GetClientsCountAsync() => _context.Clients.CountAsync();
    }
}

using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Core.Primitives.Result;
using AutoRepairService.Domain.Models;
using AutoRepairService.Domain.Repositories;
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

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var clients = await _context.Set<Client>().ToListAsync();

            if (clients is null)
                return Enumerable.Empty<Client>();
            else
                return clients;
        }

        public async Task<Maybe<Client>> GetClientByIdAsync(int id)
        {
            var client = await _context.Set<Client>().FirstOrDefaultAsync(x => x.Id == id);

            if (client is null)
                return Maybe<Client>.None;
            else
                return Maybe<Client>.From(client);
        }
    }
}

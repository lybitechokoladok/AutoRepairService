using AutoRepairService.Domain.Core.Primitives.Maybe;
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
    public class ServiceRepository : IServiceRepository
    {
        private readonly AutoRepairServiceDbContext _context;

        public ServiceRepository(AutoRepairServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServiceAsync()
        {
            var services = await _context.Set<Service>().ToListAsync();

            if(services is null)
                return Enumerable.Empty<Service>();
            else
                return services;
        }

        public async Task<Maybe<Service>> GetServiceByIdAsync(int id)
        {
            var service = await _context.Set<Service>().FirstOrDefaultAsync(x => x.Id == id);

            if (service is null)
                return Maybe<Service>.None;
            else
                return Maybe<Service>.From(service);
        }
    }
}

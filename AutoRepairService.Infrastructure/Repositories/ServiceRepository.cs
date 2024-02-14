using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
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

        Task<IEnumerable<Service>> IServiceRepository.GetAllServiceAsync()
        {
            throw new NotImplementedException();
        }

        Task<Maybe<Service>> IServiceRepository.GetServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

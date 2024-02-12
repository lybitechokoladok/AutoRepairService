using AutoRepairService.Domain.Models;
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
        public Task<Service> GetAllServiceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

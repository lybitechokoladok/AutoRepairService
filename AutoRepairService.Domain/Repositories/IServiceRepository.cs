using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<Maybe<Service>> GetServiceByIdAsync(int id);
        Task<IEnumerable<Service>> GetAllServiceAsync();
    }
}

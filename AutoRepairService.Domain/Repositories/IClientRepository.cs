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
    public interface IClientRepository
    {
        Task<Maybe<ClientDto>> GetClientByIdAsync(int id);
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<IEnumerable<ClientDto>> GetClientOffsetAsync(int size, int cursor);
    }
}

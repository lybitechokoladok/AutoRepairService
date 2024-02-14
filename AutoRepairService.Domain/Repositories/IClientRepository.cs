using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Core.Primitives.Result;
using AutoRepairService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Maybe<Client>> GetClientByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
    }
}

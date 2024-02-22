using AutoRepairService.Domain.Core.Primitives.Maybe;
using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Maybe<Client>> GetClientByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        IEnumerable<Client> GetAll();
        Task<IEnumerable<Client>> GetNextClientOffsetAsync(int size, int cursor);
        Task<IEnumerable<Client>> GetPreviosClientOffsetAsync(int size,int cursor);
        Task<int> GetClientsCountAsync();
        void Remove(Client client);
        void Update(Client client);
        void Add(Client client);
    }
}

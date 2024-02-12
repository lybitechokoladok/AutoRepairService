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
        Task<Client> GetClientByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task ChangeClientTagAsync(Client client);
    }
}

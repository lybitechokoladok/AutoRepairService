using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.Stores
{
    public class ClientStore
    {
        private readonly IClientRepository _clientRepository;
        private List<Client> _clients;
        public IEnumerable<Client> Client => _clients;

        public ClientStore(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _clients = new List<Client>();
        }

        public async Task OffsetClientLoad(int size, int cursor) 
        {
            IEnumerable<Client> clients = await _clientRepository.GetNextClientOffsetAsync(size, cursor);

            _clients.Clear();
            _clients.AddRange(clients);
        }
    }
}

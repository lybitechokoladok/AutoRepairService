using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.Stores
{
    public class SelectedClientStore
    {

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                SelectedClientChanged?.Invoke();
            }
        }

        public event Action SelectedClientChanged;
    }
}

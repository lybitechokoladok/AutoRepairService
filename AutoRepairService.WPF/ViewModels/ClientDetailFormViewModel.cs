using AutoRepairService.Domain.Entities;
using AutoRepairService.WPF.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.ViewModels
{
    public sealed class ClientDetailFormViewModel : ObservableObject
    {
        private readonly SelectedClientStore _clientStore;
        public Client Client { get; set; }

        public ClientDetailFormViewModel(SelectedClientStore clientStore)
        {
            _clientStore = clientStore;

            if(clientStore.SelectedClient == null) Client = new Client();
            else Client = clientStore.SelectedClient;
        }
    }
}

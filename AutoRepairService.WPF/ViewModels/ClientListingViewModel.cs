using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AutoRepairService.WPF.ViewModels
{
    public class ClientListingViewModel : ObservableObject
    {
        private readonly IClientRepository _clientRepository;

        private ObservableCollection<ClientDto> _clients;

        public ICollectionView ClientCollectionView { get; }
        public ClientListingViewModel(IClientRepository clientRepository)
        {
            _clients = new ObservableCollection<ClientDto>();

            _clientRepository = clientRepository;

            ClientCollectionView = CollectionViewSource.GetDefaultView(_clients);

            LoadClientCommand = new AsyncRelayCommand(LoadAllClient);
            LoadClientCommand.Execute(null);
        }

        public IAsyncRelayCommand LoadClientCommand { get; }

        private async Task LoadAllClient()
        {
            var clients = await _clientRepository.GetAllAsync();

            _clients.Clear();

            foreach (ClientDto client in clients)
            {
                _clients.Add(client);
            }
        }
    }
}

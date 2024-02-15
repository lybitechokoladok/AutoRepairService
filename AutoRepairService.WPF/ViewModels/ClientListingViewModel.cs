using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
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
        private int _cursor = 0;

        private readonly IClientRepository _clientRepository;

        private ObservableCollection<Client> _clients;

        public ICollectionView ClientCollectionView { get; }

        public IAsyncRelayCommand LoadClientOffsetCommand { get; }
        public IAsyncRelayCommand MoveToNextPageCommand { get; }
        public IAsyncRelayCommand MoveToPreviosPageCommand { get; }
        public ClientListingViewModel(IClientRepository clientRepository)
        {
            _clients = new ObservableCollection<Client>();

            _clientRepository = clientRepository;

            ClientCollectionView = CollectionViewSource.GetDefaultView(_clients);

            LoadClientOffsetCommand = new AsyncRelayCommand(LoadClientOffset);
            MoveToNextPageCommand = new AsyncRelayCommand(LoadClientOffset);
            MoveToPreviosPageCommand = new AsyncRelayCommand(LoadPreviosClientOffset);

            LoadClientOffsetCommand.Execute(null);
        }

        private async Task LoadPreviosClientOffset()
        {
            var clientOffset = await _clientRepository.GetPreviosClientOffsetAsync(20, _cursor);

            _clients.Clear();

            foreach (Client client in clientOffset)
            {
                _clients.Add(client);
            }

            _cursor = clientOffset.ToList()[0].Id;
        }

        private async Task LoadClientOffset()
        {
            var clientOffset = await _clientRepository.GetNextClientOffsetAsync(20, _cursor);

            _clients.Clear();

            foreach (Client client in clientOffset)
            {
                _clients.Add(client);
            }

            _cursor = clientOffset.ToList()[^1].Id;
        }
    }
}

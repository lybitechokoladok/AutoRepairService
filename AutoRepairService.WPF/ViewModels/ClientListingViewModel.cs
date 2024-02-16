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
    public partial class ClientListingViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _cursor = 0;

        private readonly IClientRepository _clientRepository;

        private ObservableCollection<ClientListingItemViewModel> _clients;

        public ICollectionView ClientCollectionView { get; }

        [ObservableProperty]
        private int currentPage = 1;

        [ObservableProperty]
        private int totalPage;

        [ObservableProperty]
        private int recordsCount;

        [ObservableProperty]
        private bool isStartPage = true;

        [ObservableProperty]
        private bool isEndPage;

        public IAsyncRelayCommand LoadClientOffsetCommand { get; }
        public IAsyncRelayCommand MoveToNextPageCommand { get; }
        public IAsyncRelayCommand MoveToPreviosPageCommand { get; }
        public ClientListingViewModel(IClientRepository clientRepository)
        {
            _clients = new ObservableCollection<ClientListingItemViewModel>();

            _clientRepository = clientRepository;

            ClientCollectionView = CollectionViewSource.GetDefaultView(_clients);

            LoadClientOffsetCommand = new AsyncRelayCommand(LoadClientOffset);
            MoveToNextPageCommand = new AsyncRelayCommand(LoadClientOffset);
            MoveToPreviosPageCommand = new AsyncRelayCommand(LoadPreviosClientOffset);

            LoadClientOffsetCommand.Execute(null);
        }

        private async Task LoadPreviosClientOffset()
        {
            var clientOffset = await _clientRepository.GetPreviosClientOffsetAsync(20, Cursor);

            _clients.Clear();

            foreach (Client client in clientOffset)
            {
                AddClient(client);
            }


            CurrentPage--;

            Cursor = clientOffset.ToList()[^1].Id;

            IsStartPage = CurrentPage == 1 ? true : false;
            IsEndPage = CurrentPage == TotalPage ? true : false;
        }

        private void AddClient(Client client)
        {
            ClientListingItemViewModel itemViewModel =
                new ClientListingItemViewModel(client);
            _clients.Add(itemViewModel);
        }

        private async Task LoadClientOffset()
        {
            if (recordsCount == 0)
            {
                RecordsCount = await _clientRepository.GetClientsCountAsync();

                TotalPage = RecordsCount / 20;
            }

            var clientOffset = await _clientRepository.GetNextClientOffsetAsync(20, Cursor);

            _clients.Clear();

            foreach (Client client in clientOffset)
            {
                AddClient(client);
            }


            if (Cursor != 0)
                CurrentPage++;
            Cursor = clientOffset.ToList()[^1].Id;

            IsEndPage = CurrentPage == TotalPage ? true : false;
            IsStartPage = CurrentPage == 1 ? true : false;
        }
    }
}

using AutoRepairService.Domain.Dtos;
using AutoRepairService.Domain.Entities;
using AutoRepairService.Domain.Repositories;
using AutoRepairService.WPF.Services;
using AutoRepairService.WPF.Stores;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata;
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

        private readonly IClientRepository _clientRepository;
        private readonly INavigationService _navigationService;
        private readonly SelectedClientStore _selectedClientStore;

        private ObservableCollection<ClientListingItemViewModel> _clients;

        public ICollectionView ClientCollectionView { get; }

        [ObservableProperty]
        private int _cursor = 0;

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

        private ClientListingItemViewModel _selectedClient;
        public ClientListingItemViewModel SelectedClient 
        {
            get => _selectedClient;
            set 
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));

                _selectedClientStore.SelectedClient = _selectedClient.Client;
            }
        }

        public IAsyncRelayCommand LoadClientOffsetCommand { get; }
        public IAsyncRelayCommand MoveToNextPageCommand { get; }
        public IAsyncRelayCommand MoveToPreviosPageCommand { get; }
        public RelayCommand OpenClientDetailFormCommand { get; }
        public ClientListingViewModel(
            IClientRepository clientRepository,
            SelectedClientStore selectedClientStore,
            INavigationService openClientDetailFormNavigationService)
        {
            _clients = new ObservableCollection<ClientListingItemViewModel>();

            _clientRepository = clientRepository;
            _navigationService = openClientDetailFormNavigationService;
            _selectedClientStore = selectedClientStore;

            ClientCollectionView = CollectionViewSource.GetDefaultView(_clients);

            LoadClientOffsetCommand = new AsyncRelayCommand(LoadClientOffset);
            MoveToNextPageCommand = new AsyncRelayCommand(LoadClientOffset);
            MoveToPreviosPageCommand = new AsyncRelayCommand(LoadPreviosClientOffset);
            OpenClientDetailFormCommand = new RelayCommand(OpenClientDetailForm);

            LoadClientOffsetCommand.Execute(null);
        }

        private void OpenClientDetailForm()
        => _navigationService.Navigate();

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
                new ClientListingItemViewModel(client, OpenClientDetailFormCommand);
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

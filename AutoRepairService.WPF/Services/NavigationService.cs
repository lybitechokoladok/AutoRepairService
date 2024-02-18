using AutoRepairService.WPF.Stores;
using AutoRepairService.WPF.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.Services
{
    public sealed class NavigationService<TViewModel> : INavigationService
        where TViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ObservableObject> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ObservableObject> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

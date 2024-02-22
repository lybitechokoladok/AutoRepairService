using AutoRepairService.Domain.Repositories;
using AutoRepairService.WPF.Services;
using AutoRepairService.WPF.Stores;
using AutoRepairService.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.HostBuilders
{
    public static class AddViewModel
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) 
        {
            services.AddSingleton<MainViewModel>();

            services.AddTransient<ClientListingViewModel>(s=> new ClientListingViewModel(
                s.GetRequiredService<IClientRepository>(),
                s.GetRequiredService<SelectedClientStore>(),
                CreateClientDetailFormNavigationService(s)));
            services.AddTransient<ClientDetailFormViewModel>(s => new ClientDetailFormViewModel(
                s.GetRequiredService<SelectedClientStore>(),
                s.GetRequiredService<ModalNavigationStore>(),
                s.GetRequiredService<IClientRepository>()));

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            }) ;

            return services;
        }

        private static INavigationService CreateClientDetailFormNavigationService(IServiceProvider s)
        {
            return new ModalNavigationService<ClientDetailFormViewModel>(
                s.GetRequiredService<ModalNavigationStore>(),
                () => s.GetRequiredService<ClientDetailFormViewModel>());
        }
    }
}

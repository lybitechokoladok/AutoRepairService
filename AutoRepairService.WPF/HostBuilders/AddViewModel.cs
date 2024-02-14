using AutoRepairService.Domain.Repositories;
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
            services.AddSingleton<MainViewModel>(s=> new MainViewModel() 
            {
                CurrentViewModel = s.GetRequiredService<ClientListingViewModel>()
            });

            services.AddScoped<ClientListingViewModel>(s=> new ClientListingViewModel(
                s.GetRequiredService<IClientRepository>()));

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            }) ;

            return services;
        }
    }
}

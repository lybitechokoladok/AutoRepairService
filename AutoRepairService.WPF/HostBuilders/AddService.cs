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
    public static class AddService
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddSingleton<INavigationService>(s => CreateStartNavigationService(s));
            services.AddSingleton<CloseModalNavigationService>();

            return services;
        }

        private static INavigationService CreateStartNavigationService(IServiceProvider s)
        {
            return new NavigationService<ClientListingItemViewModel>(
                s.GetRequiredService<NavigationStore>(),
                () => s.GetRequiredService<ClientListingViewModel>());
        }
    }
}

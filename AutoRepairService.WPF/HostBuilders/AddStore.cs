using AutoRepairService.WPF.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairService.WPF.HostBuilders
{
    public static class AddStore
    {
        public static IServiceCollection AddStores(this IServiceCollection services) 
        {
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();

            return services;
        }
    }
}

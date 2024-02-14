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

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            return services;
        }
    }
}

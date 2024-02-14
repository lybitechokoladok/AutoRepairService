using Microsoft.Extensions.Hosting;
using AutoRepairService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using AutoRepairService.WPF.ViewModels;
using AutoRepairService.WPF.HostBuilders;

namespace AutoRepairService.WPF
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context,services) =>
                {
                    services.AddInfrastructure(context.Configuration);
                    services.AddViewModels();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}

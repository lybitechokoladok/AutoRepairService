using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairService.Domain.Repositories;
using AutoRepairService.Infrastructure.Repositories;
using AutoRepairService.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoRepairService.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("Desktop");

            services.AddDbContext<AutoRepairServiceDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            return services;
        }
    }
}

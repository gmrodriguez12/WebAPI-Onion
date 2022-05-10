using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdventureWorkDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(AdventureRepositoryAsync<>));
        }
    }
}

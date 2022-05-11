using Shared.Services;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfra(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }       
    }
}

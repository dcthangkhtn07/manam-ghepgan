using Manam.GhepGan.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Manam.GhepGan.Business
{
    public static class BusinessServiceExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<INewsBusiness, NewsBusiness>();
            services.AddTransient<IIdentityBusiness, IdentityBusiness>();

            return services;
        }
    }
}

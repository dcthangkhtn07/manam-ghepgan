using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Manam.GhepGan.DAL
{
    public static class DALServiceExtensions
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GhepGanDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("GhepGan")));

            return services;
        }
    }
}

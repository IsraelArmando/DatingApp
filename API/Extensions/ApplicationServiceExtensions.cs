using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{//4.45{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        //4.41{
    services.AddScoped<ITokenService, TokenService>();

//2.12{
            services.AddDbContext<DataContext>(options =>{
          //      options.UseSqlite("Connection string");
                 options.UseSqlite(config.GetConnectionString("DefaultConnection"));
          
            });

//}2.12

return services;
    }
    }
//}4.45
}
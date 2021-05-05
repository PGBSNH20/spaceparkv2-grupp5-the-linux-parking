using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Domain.Services;
using LinuxParking.API.Services;
using LinuxParking.Database.Context;
using LinuxParking.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinuxParking.API.Configuration
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfig>(configuration.GetSection("Jwt"));
            services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("Default")));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
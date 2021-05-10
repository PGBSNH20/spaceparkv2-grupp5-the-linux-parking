using LinuxParking.API.Database.Context;
using LinuxParking.API.Database.Repositories;
using LinuxParking.API.Domain.Interfaces.Repositories;
using LinuxParking.API.Domain.Interfaces.Services;
using LinuxParking.API.Domain.Repositories;
using LinuxParking.API.Domain.Services;
using LinuxParking.API.Services;
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
            services.AddScoped<ISpotRepository, SpotRepository>();
            services.AddScoped<ISpotService, SpotService>();
            services.AddScoped<IParkingRepository, ParkingRepository>();
            services.AddScoped<IParkingService, ParkingService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
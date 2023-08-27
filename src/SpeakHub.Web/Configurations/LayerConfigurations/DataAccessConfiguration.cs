using Microsoft.EntityFrameworkCore;
using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.DataAccess.Repositories.Common;

namespace RegistanFerghanaLC.Web.Configuration.LayerConfigurations
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

using SpeakHub.Service.Interfaces.Common;
using SpeakHub.Service.Services.AdminService;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Service.Interfaces.Accounts;
using SpeakHub.Service.Interfaces.Admins;
using SpeakHub.Web.Configurations;
using SpeakHub.Service.Services.Common;
using SpeakHub.Service.Services.AccountService;

namespace SpeakHub.Configurations.LayerConfigurations
{
    public static class ServiceLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IIdentityService, IdentityService>();



            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}

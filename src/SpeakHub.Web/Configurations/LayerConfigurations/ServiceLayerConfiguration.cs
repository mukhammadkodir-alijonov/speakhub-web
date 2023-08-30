using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Service.Interfaces.Accounts;
using SpeakHub.Service.Interfaces.Admins;
using SpeakHub.Service.Interfaces.Common;
using SpeakHub.Service.Interfaces.Files;
using SpeakHub.Service.Interfaces.Follows;
using SpeakHub.Service.Services.AccountService;
using SpeakHub.Service.Services.AdminService;
using SpeakHub.Service.Services.Common;
using SpeakHub.Service.Services.Files;
using SpeakHub.Service.Services.FollowService;
using SpeakHub.Web.Configurations;

namespace SpeakHub.Configurations.LayerConfigurations
{
    public static class ServiceLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFollowService,FollowService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IEmailService, EmailService>();


            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}

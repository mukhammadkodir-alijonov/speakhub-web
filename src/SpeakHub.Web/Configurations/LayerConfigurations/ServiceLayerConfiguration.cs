using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.DataAccess.Repositories.Common;
using SpeakHub.Service.Interfaces.Accounts;
using SpeakHub.Service.Interfaces.Admins;
using SpeakHub.Service.Interfaces.Comments;
using SpeakHub.Service.Interfaces.Common;
using SpeakHub.Service.Interfaces.Files;
using SpeakHub.Service.Interfaces.Follows;
using SpeakHub.Service.Interfaces.Likes;
using SpeakHub.Service.Interfaces.Tweets;
using SpeakHub.Service.Interfaces.Users;
using SpeakHub.Service.Services.AccountService;
using SpeakHub.Service.Services.AdminService;
using SpeakHub.Service.Services.Comments;
using SpeakHub.Service.Services.Common;
using SpeakHub.Service.Services.FollowService;
using SpeakHub.Service.Services.Likes;
using SpeakHub.Service.Services.TweetService;
using SpeakHub.Service.Services.UserService;
using SpeakHub.Web.Configurations;

namespace SpeakHub.Configurations.LayerConfigurations
{
    public static class ServiceLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ITweetService, TweetService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPaginatorService, PaginatorService>();


            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}

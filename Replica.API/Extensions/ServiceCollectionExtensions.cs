using Business.Abstracts;
using Business.Concrete;
using DataAccess.EntityFramework.Abstracts;
using DataAccess.EntityFramework.Concrete;

namespace Replica.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IGuideRepository, GuideRepository>();
            services.AddScoped<IHardwareRepository, HardwareRepository>();
            services.AddScoped<INodeRepository, NodeRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<INodeService, NodeManager>();
            services.AddScoped<IHardwareService, HardwareManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IReviewService, ReviewManager>();
        }
    }
}

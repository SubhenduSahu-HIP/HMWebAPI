using HM_Admin.Repositorys.IRepository;
using HM_Admin.Repositorys.Repository;
using HM_Admin.Services.IService;
using HM_Admin.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;



namespace HM_Admin
{
    public static class HMAdminServiceCollectionExtention
    {
        public static IServiceCollection AddHMAdminServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped<IGetMasterDataRepository, GetMasterDataRepository>();


            return services;
        }
    }
}

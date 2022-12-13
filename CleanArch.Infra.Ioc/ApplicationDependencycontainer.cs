using Application.Common.BulkInserts;
using Application.Common.Interfaces;
using Application.Interfaces.Campaign;
using Application.Interfaces.Rol;
using Application.Interfaces.User;
using Application.Services.Campaign;
using Application.Services.Rol;
using Application.Services.User;
using CleanArch.Application.Interfaces.Auths;
using CleanArch.Application.Services.Auths;
using Domain.Interfaces;
using Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class ApplicationDependencycontainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
         
            services.AddScoped<IBulkInsert, BulkInsert>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            // Auth
            services.AddScoped<IAuthService, AuthService>();
            //Campaign
            services.AddScoped<ICampaignService, CampaignService>();
            // User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolService, RolService>();
        }
    }
}

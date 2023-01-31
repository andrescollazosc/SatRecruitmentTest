using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Abstractions;
using Sat.Recruitment.Application.Mapping;
using Sat.Recruitment.Application;
using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Core.Validations;
using Sat.Recruitment.Core;

namespace Sat.Recruitment.Api.IoC
{
    public static class Builders
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IUserCore, UserCore>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserValidations, UserValidations>();
            services.AddScoped<IBusinessRuleValidations, BusinessRuleValidations>();
        }
    }
}

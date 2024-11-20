using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CourseAppMicroservice.Shared.Extensions;

public static class CommonServiceExtension
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services, Type assembly)
    {
        services.AddHttpContextAccessor();
        services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(assembly));
        
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);
        
        services.AddAutoMapper(assembly);
        
        return services;
    }
}
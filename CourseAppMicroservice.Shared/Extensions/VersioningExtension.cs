using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CourseAppMicroservice.Shared.Extensions;

public static class VersioningExtension
{
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            // You can use many version reader option with combine.
            // options.ApiVersionReader = ApiVersionReader.Combine(
            //     new UrlSegmentApiVersionReader(),
            //     new QueryStringApiVersionReader(),
            //     new QueryStringApiVersionReader());
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
        
        return services;
    }

    public static ApiVersionSet AddVersionSet(this WebApplication app)
    {
        var apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1, 0))
            .HasApiVersion(new ApiVersion(2, 0))
            .ReportApiVersions().Build();
        
        return apiVersionSet;
    }
}
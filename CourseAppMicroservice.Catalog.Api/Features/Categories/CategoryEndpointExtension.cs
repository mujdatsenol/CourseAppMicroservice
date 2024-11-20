using Asp.Versioning.Builder;
using CourseAppMicroservice.Catalog.Api.Features.Categories.Create;
using CourseAppMicroservice.Catalog.Api.Features.Categories.GetAll;
using CourseAppMicroservice.Catalog.Api.Features.Categories.GetById;

namespace CourseAppMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void MapCategoryGroupEndpoint(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/categories")
            .WithTags("Category")
            .WithApiVersionSet(apiVersionSet)
            .CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint();
        
        //.AddEndpointFilter<ValidationFilter>();
    }
}
using Asp.Versioning.Builder;
using CourseAppMicroservice.Catalog.Api.Features.Courses.Create;
using CourseAppMicroservice.Catalog.Api.Features.Courses.Delete;
using CourseAppMicroservice.Catalog.Api.Features.Courses.GetAll;
using CourseAppMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using CourseAppMicroservice.Catalog.Api.Features.Courses.GetById;
using CourseAppMicroservice.Catalog.Api.Features.Courses.Update;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses;

public static class CourseEndpointExtension
{
    public static void MapCourseGroupEndpoint(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/courses")
            .WithTags("Course")
            .WithApiVersionSet(apiVersionSet)
            .CreateCourseGroupItemEndpoint()
            .GetAllCourseGroupItemEndpoint()
            .GetByIdCourseGroupItemEndpoint()
            .UpdateCourseGroupItemEndpoint()
            .DeleteCourseGroupItemEndpoint()
            .GetAllByUserIdCourseGroupItemEndpoint();
        
        //.AddEndpointFilter<ValidationFilter>();
    }
}
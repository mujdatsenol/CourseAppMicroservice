using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetById;

public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
{
    public async Task<ServiceResult<CourseDto>> Handle(
        GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FindAsync([request.Id], cancellationToken);
        if (course is null)
        {
            return ServiceResult<CourseDto>.Error(
                "Course not found", 
                $"The course id {request.Id} was not found", 
                HttpStatusCode.NotFound);
        }
        
        var category = await context.Categories.FindAsync([course.CategoryId], cancellationToken);
        if (category is null)
        {
            return ServiceResult<CourseDto>.Error(
                "Course category not found", 
                $"The course category id {course.CategoryId} was not found", 
                HttpStatusCode.NotFound);
        }
        
        course.Category = category;
        var courseDto = mapper.Map<CourseDto>(course);
        
        return ServiceResult<CourseDto>.SuccessAsOk(courseDto);
    }
}
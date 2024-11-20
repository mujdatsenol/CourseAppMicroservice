using CourseAppMicroservice.Catalog.Api.Features.Categories.Dto;
using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetAll;

public class GetAllCourseQuaryHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(
        GetAllCourseQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories.ToListAsync(cancellationToken);
        var courses = await context.Courses.ToListAsync(cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(c => c.Id == course.CategoryId);
        }
        
        var coursesDto = mapper.Map<List<CourseDto>>(courses);
        
        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesDto);
    }
}
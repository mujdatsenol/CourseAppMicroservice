using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public class GetAllCourseByUserIdQueryHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<GetAllCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(
        GetAllCourseByUserIdQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses
            .Where(w => w.UserId == request.UserId).ToListAsync(cancellationToken);

        if (!courses.Any())
        {
            return ServiceResult<List<CourseDto>>.Error(
                "Courses not found!",
                "Courses for this user were not found.",
                HttpStatusCode.NotFound);
        }
        
        var categories = await context.Categories.ToListAsync(cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(w => w.Id == course.CategoryId);
        }
        
        var courseDto = mapper.Map<List<CourseDto>>(courses);
        
        return ServiceResult<List<CourseDto>>.SuccessAsOk(courseDto);
    }
}
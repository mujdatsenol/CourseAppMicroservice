namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Create;

public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) 
    : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
{
    public async Task<ServiceResult<Guid>> Handle(
        CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var hasCategory = await context.Categories
            .AnyAsync(a => a.Id == request.CategoryId, cancellationToken);
        if (!hasCategory)
        {
            return ServiceResult<Guid>.Error(
                "Category does not exist", 
                $"Category id '{request.CategoryId}' does not exist", 
                HttpStatusCode.NotFound);
        }
        
        var hasCourse = await context.Courses
            .AnyAsync(a => a.Name == request.Name, cancellationToken);
        if (hasCourse)
        {
            return ServiceResult<Guid>.Error(
                "Course already exists", 
                $"Course name '{request.Name}' already exists", 
                HttpStatusCode.BadRequest);
        }
        
        var newCourse = mapper.Map<Course>(request);
        newCourse.Id = NewId.NextSequentialGuid();
        newCourse.Created = DateTime.Now;
        newCourse.Feature = new Feature()
        {
            Duration = 10, // calculate by course
            Rating = 0,
            EducatorFullName = "John Doe",
        };
        
        context.Courses.Add(newCourse);
        await context.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
    }
}
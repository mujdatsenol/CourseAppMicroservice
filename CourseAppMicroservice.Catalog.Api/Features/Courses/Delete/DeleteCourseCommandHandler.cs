namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Delete;

public class DeleteCourseCommandHandler(AppDbContext context) 
    : IRequestHandler<DeleteCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(
        DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FindAsync([request.Id], cancellationToken);
        if (course is null)
        {
            return ServiceResult.ErrorAsNotFound();
        }
        
        context.Courses.Remove(course);
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
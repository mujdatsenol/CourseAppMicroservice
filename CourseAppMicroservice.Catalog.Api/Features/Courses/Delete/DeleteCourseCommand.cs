namespace CourseAppMicroservice.Catalog.Api.Features.Courses.Delete;

public record DeleteCourseCommand(Guid Id) : IRequestService;
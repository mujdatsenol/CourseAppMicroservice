using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public record GetAllCourseByUserIdQuery(Guid UserId) : IRequestService<List<CourseDto>>;
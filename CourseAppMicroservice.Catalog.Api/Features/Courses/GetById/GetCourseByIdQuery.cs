using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetById;

public record GetCourseByIdQuery(Guid Id) : IRequestService<CourseDto>;
using CourseAppMicroservice.Catalog.Api.Features.Courses.Dto;

namespace CourseAppMicroservice.Catalog.Api.Features.Courses.GetAll;

public record GetAllCourseQuery : IRequestService<List<CourseDto>>;
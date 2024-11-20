using MediatR;

namespace CourseAppMicroservice.Shared;

public interface IRequestService<T> : IRequest<ServiceResult<T>>;
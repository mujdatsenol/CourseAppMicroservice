using MediatR;

namespace CourseAppMicroservice.Shared;

[Obsolete]
public interface IRequestHandlerService<T, H> : IRequestHandler<T, ServiceResult<H>> 
    where T : IRequest<ServiceResult<H>>;
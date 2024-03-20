using Blazor.Madiator.Mediator.PipelineBehaviours.Casche;
using Blazor.Madiator.PipelineBehaviours.Mapper;
using MediatR;

namespace Blazor.Madiator.Mediator.PipelineBehaviours
{
    public class CacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseRequest
        where TResponse : class
    {
        private readonly IEnumerable<ICache<TRequest>> _caches;
        private readonly IEnumerable<IMapper<TRequest, TResponse>> _mappers;
        public CacheBehaviour(IEnumerable<ICache<TRequest>> caches, IEnumerable<IMapper<TRequest, TResponse>> mappers)
        {
            _caches = caches;
            _mappers = mappers;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var cache = _caches.SingleOrDefault(x => x.GetRequestType() == typeof(TRequest) && x.RequestEquals(request));
            if (cache == null)
            {
                return await next();
            }
            if (cache.TryGetDto(request, out var dto))
            {
                var mapper = _mappers.SingleOrDefault(x => x.GetRequestType() == typeof(TRequest) && x.GetResponseType() == typeof(TResponse));
                if (mapper is not null)
                {
                    var result = mapper.Map(dto);
                    return result;
                }
                return dto as TResponse; //or throw "missing mapper"
            }
            return await next();
        }
    }
}

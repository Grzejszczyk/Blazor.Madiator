using Blazor.Madiator.PipelineBehaviours.Mapper;
using MediatR;

namespace Blazor.Madiator.PipelineBehaviours.Mappers.Abstract
{
    public abstract class AbstractMapper<TRequest, TResponse> : IMapper<TRequest, TResponse> where TRequest : IBaseRequest
    {
        public Type GetRequestType() => typeof(TRequest);

        public Type GetResponseType() => typeof(TResponse);

        public abstract TResponse Map(object request);
    }
}

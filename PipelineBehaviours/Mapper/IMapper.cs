namespace Blazor.Madiator.PipelineBehaviours.Mapper
{
    public interface IMapper { }
    public interface IMapper<TRequest, TResponse> : IMapper
    {
        Type GetRequestType();
        Type GetResponseType();
        TResponse Map(object request);
    }
}
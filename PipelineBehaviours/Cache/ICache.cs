namespace Blazor.Madiator.Mediator.PipelineBehaviours.Casche
{
    public interface ICache { }
    public interface ICache<TRequest> : ICache
    {
        Type GetRequestType();
        bool RequestEquals(TRequest request);
        object GetDto();
        bool TryGetDto(TRequest request, out object dto);
        void SetDto(TRequest request, object dto);
        bool IsAlive();
        ICache<TRequest> SetMaxAge(TimeSpan maxAge);
        void Clear();
    }
}

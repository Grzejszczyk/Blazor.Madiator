using MediatR;

namespace Blazor.Madiator.Mediator.PipelineBehaviours.Casche
{
    public abstract class AbstractCache<TRequest> : ICache<TRequest>
        where TRequest : IBaseRequest
    {
        private object dto;
        private TRequest request;
        private DateTime setupDateTime;
        private TimeSpan maxAge = TimeSpan.FromMinutes(5);

        public void Clear()
        {
            dto = null;
        }

        public Type GetRequestType()
        {
            return typeof(TRequest);
        }

        public virtual object GetDto()
        {
            if (!IsAlive())
                Clear();
            return dto;
        }

        public bool IsAlive()
        {
            var DtResult = setupDateTime + maxAge > DateTime.Now;
            return dto is not null && DtResult;
        }

        public ICache<TRequest> SetMaxAge(TimeSpan maxAge)
        {
            this.maxAge = maxAge;
            return this;
        }

        public void SetDto(TRequest request, object dto)
        {
            this.dto = dto;
            this.request = request;
            setupDateTime = DateTime.Now;
        }

        public virtual bool TryGetDto(TRequest request, out object dto)
        {
            if (IsAlive() && request.Equals(this.request))
            {
                dto = this.dto;
                return true;
            }
            dto = null;
            return false;
        }

        public bool RequestEquals(TRequest request)
        {
            return request.Equals(this.request);
        }
    }
}

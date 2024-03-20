using Blazor.Madiator.Mediator.PipelineBehaviours.Casche;
using Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery.Sample;
using Blazor.Madiator.PipelineBehaviours.Mapper;
using Blazor.Madiator.ViewModels;
using MediatR;

namespace Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery
{
    public class WeatherForecastQueryHandler : IRequestHandler<WeatherForecastQuery, WeatherForecastVm[]>
    {
        private readonly IEnumerable<IMapper<WeatherForecastQuery, WeatherForecastVm[]>> _mappers;
        private readonly IEnumerable<ICache<WeatherForecastQuery>> _caches;

        public WeatherForecastQueryHandler(IEnumerable<ICache<WeatherForecastQuery>> caches, IEnumerable<IMapper<WeatherForecastQuery, WeatherForecastVm[]>> mappers)
        {
            _mappers = mappers;
            _caches = caches;
        }

        public async Task<WeatherForecastVm[]> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await SampleData.GetWeatherForecastsAsync();
            var dto = forecasts.Take(request.ForecastsCount);
            if (dto is not null)
            {
                var cache = _caches.SingleOrDefault(x => x.GetRequestType() == typeof(WeatherForecastQuery));
                if (cache is not null)
                {
                    cache
                        .SetMaxAge(TimeSpan.FromMinutes(1))
                        .SetDto(request, dto);
                }
            }
            var mapper = _mappers.SingleOrDefault(x => x.GetRequestType() == typeof(WeatherForecastQuery) && x.GetResponseType() == typeof(WeatherForecastVm[]));
            if (mapper is not null)
            {
                var result = mapper.Map(dto);
                return result;
            }
            return (WeatherForecastVm[])dto; //or throw ex "missing mapper"
        }
    }
}

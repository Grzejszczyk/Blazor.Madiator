using Blazor.Madiator.ViewModels;
using MediatR;

namespace Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery
{
    public class WeatherForecastQuery : IRequest<WeatherForecastVm[]>
    {
        public int ForecastsCount { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is WeatherForecastQuery query &&
                   ForecastsCount == query.ForecastsCount;
        }
    }
}

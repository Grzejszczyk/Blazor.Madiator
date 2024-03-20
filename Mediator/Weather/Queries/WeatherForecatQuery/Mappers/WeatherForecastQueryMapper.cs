using Blazor.Madiator.PipelineBehaviours.Mappers.Abstract;
using Blazor.Madiator.ViewModels;

namespace Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery.Mappers
{
    public class WeatherForecastQueryMapper : AbstractMapper<WeatherForecastQuery, WeatherForecastVm[]>
    {
        public override WeatherForecastVm[] Map(object request)
        {
            var dto = (IEnumerable<WeatherForecastVm>)request;
            var result = dto.ToArray();
            return result;
        }
    }
}

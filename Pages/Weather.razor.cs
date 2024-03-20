using Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery;
using Blazor.Madiator.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Blazor.Madiator.Pages
{
    public partial class Weather
    {
        [Inject] IMediator Mediator { get; set; }
        private WeatherForecastVm[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            //forecasts = await Http.GetFromJsonAsync<WeatherForecastVm[]>("sample-data/weather.json");
            var query = new WeatherForecastQuery() { ForecastsCount = 3 };
            forecasts = await Mediator.Send(query);
        }
    }
}
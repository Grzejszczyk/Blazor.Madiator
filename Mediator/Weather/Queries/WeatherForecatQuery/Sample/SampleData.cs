using Blazor.Madiator.ViewModels;

namespace Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery.Sample
{
    public static class SampleData
    {
        public static async Task<IEnumerable<WeatherForecastVm>> GetWeatherForecastsAsync()
        {
            return await Task.FromResult(GetWeatherForecasts());
        }

        private static IEnumerable<WeatherForecastVm> GetWeatherForecasts()
        {
            var forecasts = new List<WeatherForecastVm>();
            var vm1 = new WeatherForecastVm
            {
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                Summary = "Freezing",
                TemperatureC = 1,
            };
            var vm2 = new WeatherForecastVm
            {
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                Summary = "Bracing",
                TemperatureC = 14,
            };
            var vm3 = new WeatherForecastVm
            {
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
                Summary = "Freezing",
                TemperatureC = -13,
            };
            var vm4 = new WeatherForecastVm
            {
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(4)),
                Summary = "Balmy",
                TemperatureC = -16,
            };
            var vm5 = new WeatherForecastVm
            {
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(5)),
                Summary = "Chilly",
                TemperatureC = -1,
            };
            forecasts.Add(vm1);
            forecasts.Add(vm2);
            forecasts.Add(vm3);
            forecasts.Add(vm4);
            forecasts.Add(vm5);

            return forecasts;
        }
    }
}

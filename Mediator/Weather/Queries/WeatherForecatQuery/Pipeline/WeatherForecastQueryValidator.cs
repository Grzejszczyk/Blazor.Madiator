using FluentValidation;
using FluentValidation.Results;

namespace Blazor.Madiator.Mediator.Weather.Queries.WeatherForecatQuery.Pipeline
{
    public class WeatherForecastQueryValidator : AbstractValidator<WeatherForecastQuery>
    {
        public WeatherForecastQueryValidator()
        {
            RuleFor(x => x.ForecastsCount).GreaterThan(0).LessThanOrEqualTo(5).NotEmpty();
        }

        public override ValidationResult Validate(ValidationContext<WeatherForecastQuery> context)
        {
            return base.Validate(context);
        }
    }
}

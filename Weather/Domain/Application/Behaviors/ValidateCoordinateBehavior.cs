using Domain.Common;
using Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
	public class ValidateCoordinateBehavior
        : IPipelineBehavior<Coordinates, WeatherStatistics>
	{
        private readonly IValidator<Coordinates> _validator;

        public ValidateCoordinateBehavior(IValidator<Coordinates> validator)
		{
            _validator = validator;
        }

        public async Task<WeatherStatistics> Handle(
            Coordinates request,
            RequestHandlerDelegate<WeatherStatistics> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                return await next();
            }
            throw new InvalidCoordinatesException();
        }
    }
}


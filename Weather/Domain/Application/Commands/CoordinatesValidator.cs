using Domain.Common;
using FluentValidation;

namespace Application.Commands
{
	public class CoordinatesValidator : AbstractValidator<Coordinates>
	{
		public CoordinatesValidator()
		{
            RuleFor(x => x.Latitude).NotEmpty();
			RuleFor(x => x.Longitude).NotEmpty();
		}
	}
}


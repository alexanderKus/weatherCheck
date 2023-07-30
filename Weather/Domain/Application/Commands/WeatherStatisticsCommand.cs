using Domain.Common;
using MediatR;

namespace Application.Commands;


public record WeatherStatisticsCommand(Coordinates Coordinates)
	: IRequest<WeatherStatistics>;


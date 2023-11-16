using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class GetWeatrerBroadcastHandler : IRequestHandler<GetWeatherBroadcastQuery, IEnumerable<WeatherForecast>>
{
	private static readonly string[] Summaries = new[]
	{
		"Testing1", "testing2"
	};

	public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherBroadcastQuery request, CancellationToken cancellationToken)
	{
		await Task.Delay(2000);
		return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		})
		.ToArray();
	}
}

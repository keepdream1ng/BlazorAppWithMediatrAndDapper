using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWithMediatrAndDapper.PLL; 

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

	private readonly ILogger<WeatherForecastController> _logger;
	private readonly IMediator _mediator;

	public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
	{
		_logger = logger;
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IEnumerable<WeatherForecast>> Get()
	{
		return await _mediator.Send(new GetWeatherBroadcastQuery());
	}
}
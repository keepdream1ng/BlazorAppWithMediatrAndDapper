using BlazorAppWithMediatrAndDapper.BLL.Commands;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWithMediatrAndDapper.PLL; 

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{

	private readonly IMediator _mediator;

	public OrderController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost]
	public async Task<IActionResult> Post(OrderOptionsViewModel orderViewModel)
	{
		var order = await _mediator.Send(new CreateOrderCommand(orderViewModel));
		return Ok();
	}

	[HttpPut]
	public async Task<IActionResult> Put(OrderOptionsViewModel orderViewModel)
	{
		var model = orderViewModel;
		return Ok();
	}
}

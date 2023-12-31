﻿using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWithMediatrAndDapper.PLL; 

[ApiController]
[Route("[controller]")]
public class ProvidersController : ControllerBase
{

	private readonly IMediator _mediator;

	public ProvidersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		Provider[] providers = await _mediator.Send(new GetAllProvidersQuery());
		return Ok(providers);
	}
}

using AutoMapper;
using BlazorAppWithMediatrAndDapper.BLL.Commands;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	private readonly OrderRepository _orderRepository;

	public CreateOrderHandler(IMediator mediator, IMapper mapper)
    {
		_mediator = mediator;
		_mapper = mapper;
	}
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		// Getting new Id for creating Order aggregate.
		Provider provider = await _mediator.Send(new GetProviderByIdQuery(request.Model.ProviderId));
		int newId = await _mediator.Send(new GetNewOrderIdQuery());
		request.Model.ItemsList.ForEach(item => item.OrderId = newId);
		List<OrderItem> items = _mapper.Map<List<OrderItemViewModel>, List<OrderItem>>(request.Model.ItemsList);
		Order newOrder = new Order(newId, request.Model.Number, provider);
		items.ForEach(item =>newOrder.AddItem(item));
		// Adding aggregate to db as a transaction.
		var result = await _mediator.Send(new IncertNewOrderCommand(newOrder));
		if (result == request.Model.ItemsList.Count + 1)
		{
			return newOrder;
		}
		else
		{
			throw new Exception("Order Failed to insert");
		}
	}
 
}

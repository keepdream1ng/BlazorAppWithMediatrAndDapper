using AutoMapper;
using BlazorAppWithMediatrAndDapper.BLL.Commands;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class IncertNewOrderHandler : IRequestHandler<IncertNewOrderCommand, int>
{
	private readonly OrderRepository _orderRepository;
	private readonly IMapper _mapper;

	public IncertNewOrderHandler(OrderRepository orderRepository, IMapper mapper)
    {
		_orderRepository = orderRepository;
		_mapper = mapper;
	}
    public async Task<int> Handle(IncertNewOrderCommand request, CancellationToken cancellationToken)
	{
		var orderEntity = _mapper.Map<Order, OrderEntity>(request.order);
		return await _orderRepository.Create(orderEntity);
	}
}

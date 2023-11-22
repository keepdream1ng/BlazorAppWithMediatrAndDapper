using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class GetNewOrderIdHandler : IRequestHandler<GetNewOrderIdQuery, int>
{
	private readonly OrderRepository _orderRepository;

	public GetNewOrderIdHandler(OrderRepository repository)
    {
		_orderRepository = repository;
	}
    public async Task<int> Handle(GetNewOrderIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _orderRepository.GetMaxId();
		return ++result;
	}
}

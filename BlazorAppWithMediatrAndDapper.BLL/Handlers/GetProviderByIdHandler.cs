using AutoMapper;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class GetProviderByIdHandler : IRequestHandler<GetProviderByIdQuery, Provider>
{
	private readonly IProviderRepository _repo;
	private readonly IMapper _mapper;

	public GetProviderByIdHandler(IProviderRepository repo, IMapper mapper)
    {
		_repo = repo;
		_mapper = mapper;
	}

	public async Task<Provider> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
	{
		var providerEntity = await _repo.GetById(request.Id);
		Provider result = _mapper.Map<ProviderEntity, Provider>(providerEntity);
		return result;
	}
}

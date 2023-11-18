using AutoMapper;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class GetAllProvidersHandler : IRequestHandler<GetAllProvidersQuery, List<Provider>>
{
	private readonly ProviderRepository _repo;
	private readonly IMapper _mapper;

	public GetAllProvidersHandler(ProviderRepository repo, IMapper mapper)
    {
		_repo = repo;
		_mapper = mapper;
	}
    public async Task<List<Provider>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
	{
		var entities = await _repo.GetAll();
		List<Provider> result = _mapper.Map<List<ProviderEntity>, List<Provider>>(entities);
		return result;
    }
}


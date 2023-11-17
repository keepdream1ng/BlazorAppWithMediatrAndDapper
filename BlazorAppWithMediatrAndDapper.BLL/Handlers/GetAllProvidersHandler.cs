using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.BLL.Queries;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using BlazorAppWithMediatrAndDapper.DAL.Repositories;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Handlers;

public class GetAllProvidersHandler : IRequestHandler<GetAllProvidersQuery, List<Provider>>
{
	private readonly ProviderRepository _repo;

	public GetAllProvidersHandler(ProviderRepository repo)
    {
		_repo = repo;
	}
    public async Task<List<Provider>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
	{
		var entities = await _repo.GetAll();
		List<Provider> result = new();
        foreach (ProviderEntity item in entities)
        {
			result.Add(new Provider() { Name = item.Name});
        }
		return result;
    }
}


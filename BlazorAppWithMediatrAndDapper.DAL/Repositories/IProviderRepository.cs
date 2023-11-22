using BlazorAppWithMediatrAndDapper.DAL.Entities;

namespace BlazorAppWithMediatrAndDapper.DAL.Repositories;

public interface IProviderRepository
{
	Task<List<ProviderEntity>> GetAll();
	Task<ProviderEntity> GetById(int id);
}
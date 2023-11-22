using BlazorAppWithMediatrAndDapper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWithMediatrAndDapper.DAL.Repositories;

public class ProviderRepository : BaseRepository, IProviderRepository
{
	public async Task<List<ProviderEntity>> GetAll()
	{
		var result = await QueryAsync<ProviderEntity>(@"select * from Provider");
		return result;
	}

	public async Task<ProviderEntity> GetById(int id)
	{
		var result = await QueryFirstOrDefaultAsync<ProviderEntity>(@"select * from Provider where Id = :id_p", new { id_p = id });
		return result;
	}
}

using BlazorAppWithMediatrAndDapper.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWithMediatrAndDapper.DAL.Repositories;

public class ProviderRepository : BaseRepository
{
	public async Task<List<ProviderEntity>> GetAll()
	{
		var result = await QueryAsync<ProviderEntity>(@"select * from Provider");
		return result;
	}
}

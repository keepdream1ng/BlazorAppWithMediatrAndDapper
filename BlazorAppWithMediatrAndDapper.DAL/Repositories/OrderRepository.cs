using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using Dapper;

namespace BlazorAppWithMediatrAndDapper.DAL.Repositories;

public class OrderRepository : BaseRepository
{
	public async Task<int> InsertWithItems(OrderEntity order, List<OrderItemEntity> orderItems)
	{
		int result = 0;
		using (var connection = CreateConnectionQuery())
		{
			connection.Open();
			using (var transaction = connection.BeginTransaction())
			{
				try
				{
					result = connection.Execute("insert into \"Order\" (Number, Date, ProviderId) values (:Number,:Date,:ProviderId)", order);
					foreach (OrderItemEntity orderItem in orderItems)
					{
						result +=  connection.Execute(@"insert into OrderItem (OrderId, Name, Quantity, Unit) values (:OrderId,:Name,:Quantity,:Unit)", orderItem);
					}

					transaction.Commit();
					return result;
				}
				catch 
				{
					transaction.Rollback();
					throw;
				}
			}
		}
	}
	public async Task<int> Create(OrderEntity orderEntity)
	{
		var result = await ExecuteAsync("insert into \"Order\" (Number, Date, ProviderId) values (:Number,:Date,:ProviderId)",
			orderEntity);
		return result;
	}
	public async Task<List<OrderEntity>> GetAll()
	{
		var result = await QueryAsync<OrderEntity>("select * from \"Order\"");
		return result;
	}

	public async Task<OrderEntity> GetById(int id)
	{
		var result = await QueryFirstOrDefaultAsync<OrderEntity>("select * from \"Order\" where Id = :id_p", new { id_p = id });
		return result;
	}

	public async Task<int> Update(OrderEntity orderEntity)
	{
		var result = await ExecuteAsync("update \"Order\" set Number = :Number, Date = :Date, ProviderId = :ProviderId where Id = :Id", orderEntity);
		return result;
	}

	public async Task<int> DeleteById(int id)
	{
		var result = await ExecuteAsync("delete * from \"Order\" where Id = :id_p", new { id_p = id });
		return result;
	}

	public async Task<int> GetMaxId()
	{
		using (var connection = CreateConnectionQuery())
		{
			connection.Open();
			var result = await connection.ExecuteScalarAsync<int>("select MAX(Id) from \"Order\"");
			return result;
		}
	}
}

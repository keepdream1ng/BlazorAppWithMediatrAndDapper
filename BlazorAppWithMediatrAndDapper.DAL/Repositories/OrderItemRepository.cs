using BlazorAppWithMediatrAndDapper.BLL.Models;

namespace BlazorAppWithMediatrAndDapper.DAL.Repositories;

public class OrderItemRepository : BaseRepository
{
	public async Task<int> Create(OrderItemEntity orderItemEntity)
	{
		var result = await ExecuteAsync(@"insert into OrderItem (OrderId, Name, Quantity, Unit) values (:OrderId,:Name,:Quantity,:Unit)",
			orderItemEntity);
		return result; 
	}
	public async Task<List<OrderItemEntity>> GetAllByOrderId(int id)
	{
		var result = await QueryAsync<OrderItemEntity>(@"select * from OrderItem where OrderId = :orderId_p", new {orderId_p = id});
		return result;
	}

	public async Task<OrderItemEntity> GetById(int id)
	{
		var result = await QueryFirstOrDefaultAsync<OrderItemEntity>("select * from OrderItem where Id = :id_p", new { id_p = id });
		return result;
	}

	public async Task<int> Update(OrderItemEntity orderItemEntity)
	{
		var result = await ExecuteAsync(@"update OrderItem set OrderId = :OrderId, Name = :Name, Quantity = :Quantity, Unit = :Unit where Id = :Id", orderItemEntity);
		return result;
	}

	public async Task<int> DeleteById(int id)
	{
		var result = await ExecuteAsync("delete * from OrderItem where Id = :id_p", new { id_p = id });
		return result;
	}

	public async Task<int> DeleteByOrderId(int id)
	{
		var result = await ExecuteAsync("delete * from OrderItem where OrderId = :id_p", new { id_p = id });
		return result;
	}
}

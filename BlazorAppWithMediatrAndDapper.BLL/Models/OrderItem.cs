namespace BlazorAppWithMediatrAndDapper.BLL.Models;

public class OrderItem
{
	public int Id { get; private set; }
	public int OrderId { get; private set; }
	public string Name { get; private set; }
	public decimal Quantity { get; private set; }
	public string Unit { get; private set; }

	private OrderItem() { }
	internal OrderItem(int orderId, string name, uint quantity, string unit, int id = default)
	{
		if (orderId < 1)
		{
			throw new ArgumentException("OrderItem needs to be apllyed to an order", nameof(orderId));
		}
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentException("OrderItem name cannot be empty", nameof(name));
		}
		if (quantity <= 0.001)
		{
			throw new ArgumentException("Quantity must be at least 0.001", nameof(quantity));
		}
		if (string.IsNullOrEmpty(unit))
		{
			throw new ArgumentException("OrderItem unit cannot be empty", nameof(name));
		}

		Id = id;
		OrderId = orderId;
		Name = name;
		Quantity = quantity;
		Unit = unit;
	}
}

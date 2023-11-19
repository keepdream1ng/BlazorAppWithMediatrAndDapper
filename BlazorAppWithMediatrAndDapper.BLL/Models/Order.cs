using System.Collections.ObjectModel;

namespace BlazorAppWithMediatrAndDapper.BLL.Models;

public class Order
{
	public int Id { get; private set; }
	public string Number { get; private set; }
	public DateOnly Date { get; private set; }
	public Provider Provider { get; private set; }

	internal List<OrderItem> _items;
	public ReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

	private Order() { }
	public Order(string number, Provider provider, List<OrderItem> items = null)
	{
		if (string.IsNullOrEmpty(number))
		{
			throw new ArgumentException("OrderItem name cannot be empty", nameof(number));
		}
		Number = number;
		Date = DateOnly.FromDateTime(DateTime.Now);
		Provider = provider;
		if (items != null)
		{
			_items = items;
		}
		else
		{
			_items = [];
		}
	}

	public void AddItem(OrderItem item)
	{
		if (item.OrderId != this.Id)
		{
			throw new ArgumentException("OrderItem should have correct OrderId", nameof(item.OrderId));
		}
		if (item.Name == this.Number)
		{
			// Custom business logic for agregate.
			throw new ArgumentException("OrderItem's name cannot duplicate order number", nameof(item.Name));
		}
		_items.Add(item);
	}

	public void RemoveItem(int id)
	{
		var foundItem = _items.Single(x => x.Id == id);
		_items.Remove(foundItem);
	}
}

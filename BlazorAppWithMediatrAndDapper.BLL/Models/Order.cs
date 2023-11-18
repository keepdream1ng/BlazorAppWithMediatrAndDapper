using System.Collections.ObjectModel;

namespace BlazorAppWithMediatrAndDapper.BLL.Models;

public class Order
{
	public int Id { get; private set; }
	public string Number { get; private set; }
	public DateOnly Date {  get; private set; }
	public Provider Provider { get; private set; }

	internal List<OrderItem> _items = new();
	public ReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
}

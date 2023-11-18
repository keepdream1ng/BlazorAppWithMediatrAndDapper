namespace BlazorAppWithMediatrAndDapper.BLL.Models;

public class OrderItem
{
	public int Id { get; private set; }
	public string Name { get; private set; }
	public uint Quantity { get; private set; }
	public string Unit { get; private set; }
}

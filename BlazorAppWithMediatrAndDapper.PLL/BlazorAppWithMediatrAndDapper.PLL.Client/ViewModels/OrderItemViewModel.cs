using System.ComponentModel.DataAnnotations;

namespace BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;

public class OrderItemViewModel
{
	public int Id { get; set; }
	public int OrderId { get; set; }

	[Required]
	public string Name { get; set; }
	public uint Quantity { get; set; }
	public string Unit { get; set; }
}

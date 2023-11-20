using System.ComponentModel.DataAnnotations;

namespace BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;

public class OrderItemViewModel
{
	public int Id { get; set; }
	public int OrderId { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	[Range(1, int.MaxValue, ErrorMessage = "Quantity should be at least 1")]
	public int Quantity { get; set; }

	[Required]
	public string Unit { get; set; }
}

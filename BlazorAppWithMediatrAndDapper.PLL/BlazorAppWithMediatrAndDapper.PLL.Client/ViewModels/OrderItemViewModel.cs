using System.ComponentModel.DataAnnotations;

namespace BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;

public class OrderItemViewModel
{
	public int Id { get; set; }
	public int OrderId { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	[Range(0.001, double.MaxValue, ErrorMessage = "Quantity should be at least 0.001")]
	public decimal Quantity { get; set; }

	[Required]
	public string Unit { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;

public class OrderOptionsViewModel
{
	public bool ExistingOrder { get; set; }
	public int OrderId { get; set; }

	[Required]
	public string Number { get; set; }

	[Required]
	[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

	[Required]
	[Range(1, int.MaxValue, ErrorMessage = "Provider must be picked")]
	public int ProviderId { get; set; }

	public List<OrderItemViewModel> ItemsList { get; set; } = new();
	public IQueryable<OrderItemViewModel> Items => ItemsList.AsQueryable();

	[Range(1, int.MaxValue, ErrorMessage = "There should be at least one item in the order")]
	public int ItemListCount => ItemsList.Count;
}

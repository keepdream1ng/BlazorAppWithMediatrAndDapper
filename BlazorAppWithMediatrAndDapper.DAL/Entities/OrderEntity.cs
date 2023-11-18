using System.Collections.ObjectModel;

namespace BlazorAppWithMediatrAndDapper.DAL.Entities;

public class OrderEntity
{
	public int Id { get; set; }
	public string Number { get; set; }
	public DateOnly Date {  get; set; }
	public int ProviderId { get; set; }
}

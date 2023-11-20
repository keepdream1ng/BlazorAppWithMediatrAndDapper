﻿namespace BlazorAppWithMediatrAndDapper.BLL.Models;

public class OrderItemEntity
{
	public int Id { get; set; }
	public int OrderId { get; set; }
	public string Name { get; set; }
	public decimal Quantity { get; set; }
	public string Unit { get; set; }
}

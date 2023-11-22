using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Commands;

public record CreateOrderCommand(OrderOptionsViewModel Model) : IRequest<Order>;

using BlazorAppWithMediatrAndDapper.BLL.Models;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Queries;

public record GetProviderByIdQuery(int Id) : IRequest<Provider>;

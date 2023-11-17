using BlazorAppWithMediatrAndDapper.BLL.Models;
using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Queries;

public record GetAllProvidersQuery() : IRequest<List<Provider>>;

using MediatR;

namespace BlazorAppWithMediatrAndDapper.BLL.Queries;

public record GetNewOrderIdQuery() : IRequest<int>;

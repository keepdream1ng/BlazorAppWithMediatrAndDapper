using BlazorAppWithMediatrAndDapper.BLL.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppWithMediatrAndDapper.BLL.Commands;

public record IncertNewOrderCommand(Order order) : IRequest<int>;

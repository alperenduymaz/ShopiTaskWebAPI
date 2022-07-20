using MediatR;

namespace ShopiTaskWebAPI.Models.Commands
{
    public class InsertOrderCommand : IRequest<List<Order>>
    {
        public List<Order> Orders { get; set; }

    }
}

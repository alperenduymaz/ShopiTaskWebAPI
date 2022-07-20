using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopiTaskWebAPI.Models;
using ShopiTaskWebAPI.Models.Commands;

namespace ShopiTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopiTaskController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly DataContext _context;
        public ShopiTaskController(IMediator mediator, DataContext dataContext)
        {
            this.mediator = mediator;
            _context = dataContext;
        }

        [HttpPost("search")]
        public async Task<ActionResult<List<Order>>> SearchOrders(OrderFilterModel request)
        {
            var result = mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return BadRequest("Order not found.");
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(InsertOrderCommand command)
        {
            if (command.Orders.All(x => x.BrandId == 0))
            {
                return BadRequest();
            }
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}

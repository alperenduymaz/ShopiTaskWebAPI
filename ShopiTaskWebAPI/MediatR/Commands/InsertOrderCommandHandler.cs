using MediatR;
using ShopiTaskWebAPI.Models;
using ShopiTaskWebAPI.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ShopiTaskWebAPI.MediatR.Commands
{

        public class InsertOrderCommandHandler : IRequestHandler<InsertOrderCommand, List<Order>>
        {
            private readonly DataContext _context;

            public InsertOrderCommandHandler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Order>> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
            {
                var orders = new List<Order>();
                foreach(var item in request.Orders)
                {
                    if(item.BrandId == 0)
                        continue;

                 
                    item.CreatedOn = DateTime.Now;
                    _context.Orders.Add(item);
                    await _context.SaveChangesAsync(cancellationToken);
                    orders.Add(item);
                    
                }
                return orders;
            }
        }
    
}

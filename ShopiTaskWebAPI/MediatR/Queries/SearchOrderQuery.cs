using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using ShopiTaskWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ShopiTaskWebAPI.MediatR.Queries
{
    public class SearchOrderQueryHandler : IRequestHandler<OrderFilterModel, List<Order>>
    {
        //private readonly string _dbConnection;
        private readonly DataContext _dataContext;

        public SearchOrderQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Order>> Handle(OrderFilterModel request, CancellationToken cancellationToken)
        {
            var orders = _dataContext.Orders.ToList();

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                orders = orders.Where(x => x.CustomerName.Contains(request.SearchText) || x.StoreName.Contains(request.SearchText)).ToList();
            }
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                //"Id", "BrandId", "Price", "StoreName", "CustomerName", "CreatedOn", "Status" değerlerini alabilir

                if (request.SortBy == "Price")
                {
                    orders = orders.OrderBy(x => x.Price).ToList();
                }
                else if (request.SortBy == "BrandId")
                {
                    orders = orders.OrderBy(x => x.BrandId).ToList();
                }
                else if (request.SortBy == "StoreName")
                {
                    orders = orders.OrderBy(x => x.StoreName).ToList();
                }
                else if (request.SortBy == "CustomerName")
                {
                    orders = orders = orders.OrderBy(x => x.CustomerName).ToList();
                }
                else if (request.SortBy == "CreatedOn")
                {
                    orders = orders.OrderBy(x => x.CreatedOn).ToList();
                }
                else if (request.SortBy == "Status")
                {
                    orders = orders.OrderBy(x => x.Status).ToList();
                }
                else
                {
                    orders = orders.OrderBy(x => x.Id).ToList();
                }

            }
            if (request.Statuses.Count > 0)
            {
                orders = orders.Where(x => request.Statuses.Contains(x.Status)).ToList();
            }

            if(request.StartDate != null)
            {
                orders = orders.Where(x => x.CreatedOn >= request.StartDate).ToList();
            }
            if (request.EndDate != null)
            {
                orders = orders.Where(x => x.CreatedOn <= request.EndDate).ToList();
            }

            orders = orders.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

            return orders.ToList();

            }
        }
    }


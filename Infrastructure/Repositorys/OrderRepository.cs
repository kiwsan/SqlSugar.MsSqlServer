using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Factorys;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        protected override string ConnectionString { get; set; }
        protected override DbType? DatabaseType { get; set; }

        public void AddRang(int newCustomerId, IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                order.CustomerId = newCustomerId;
                order.Id = (int)Insert(order);
            }
        }

    }
}

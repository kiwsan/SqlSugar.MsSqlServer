using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [SugarTable("Order")]
    public class Order : ModelContext
    {

        public Order()
        {

        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual IEnumerable<OrderItem> TableOrderItems
        {
            get
            {
                return base.CreateMapping<OrderItem>().Where(it => it.OrderId == this.Id).ToList();
            }
        }

        [SugarColumn(IsIgnore = true)]
        public virtual Customer TableCustomer
        {
            get
            {
                return base.CreateMapping<Customer>().Single(it => it.Id == this.CustomerId);
            }
        }

    }
}

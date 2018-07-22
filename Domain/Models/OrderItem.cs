using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [SugarTable("OrderItem")]
    public class OrderItem : ModelContext
    {

        public OrderItem()
        {

        }

        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual Product TableProduct
        {
            get
            {
                return base.CreateMapping<Product>().Single(it => it.Id == this.ProductId);
            }
        }

        [SugarColumn(IsIgnore = true)]
        public virtual Order TableOrder
        {
            get
            {
                return base.CreateMapping<Order>().Single(it => it.Id == this.OrderId);
            }
        }

    }
}

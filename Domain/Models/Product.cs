using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    [SugarTable("Product")]
    public class Product : ModelContext
    {

        public Product()
        {

        }

        public int Id { get; set; }

        public string ProductName { get; set; }

        public int SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual Supplier TableSupplier { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual IEnumerable<OrderItem> TableOrderItems
        {
            get
            {
                return base.CreateMapping<OrderItem>().Where(it => it.ProductId == this.Id).ToList();
            }
        }

    }
}

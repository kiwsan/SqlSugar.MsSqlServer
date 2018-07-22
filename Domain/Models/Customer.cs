using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    [SugarTable("Customer")]
    public class Customer : ModelContext
    {

        public Customer() { }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual IEnumerable<Order> TableOrders
        {
            get
            {
                return base.CreateMapping<Order>().Where(it => it.CustomerId == this.Id).ToList();
            }
        }

    }
}

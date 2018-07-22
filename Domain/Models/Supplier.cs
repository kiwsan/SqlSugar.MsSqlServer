using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    [SugarTable("Supplier")]
    public class Supplier : ModelContext
    {

        public Supplier()
        {

        }

        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual IEnumerable<Product> TableProducts
        {
            get
            {
                return base.CreateMapping<Product>().Where(it => it.SupplierId == this.Id).ToList();
            }
        }

    }
}

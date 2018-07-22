using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Dtos
{
    public class OrderDto
    {

        protected OrderDto() { }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalAmount { get; set; }

        public OrderDto(DateTime orderDate, string orderNumber, decimal? totalAmount)
        {
            OrderDate = orderDate;
            OrderNumber = orderNumber;
            TotalAmount = totalAmount;
        }

    }
}

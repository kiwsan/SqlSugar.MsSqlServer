using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Dtos
{
    public class CustomerDto
    {

        public CustomerDto() { }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public List<OrderDto> TableOrderDtos { get; private set; }

        public CustomerDto(string firstName, string lastName, string city, string country, string phone, List<OrderDto> orderDtos = null)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Phone = phone;
            AddRang(orderDtos);
        }

        public CustomerDto(int id, string firstName, string lastName, string city, string country, string phone, List<OrderDto> orderDtos = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Phone = phone;
            AddRang(orderDtos);
        }

        private void AddRang(List<OrderDto> orderDtos)
        {
            if (orderDtos.Any())
            {
                TableOrderDtos = new List<OrderDto>();

                TableOrderDtos.AddRange(orderDtos);
            }

        }

    }
}

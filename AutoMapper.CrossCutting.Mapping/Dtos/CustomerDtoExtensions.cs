using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace AutoMapper.CrossCutting.Mapping.Dtos
{
    public static class CustomerDtoExtensions
    {

        public static CustomerDto ToModel(this Customer entity)
        {
            return entity.MapTo<Customer, CustomerDto>();
        }

        public static Customer ToEntity(this CustomerDto model)
        {
            return model.MapTo<CustomerDto, Customer>();
        }

        public static IEnumerable<Customer> ToEntity(this IEnumerable<CustomerDto> model)
        {
            return model.MapTo<IEnumerable<CustomerDto>, IEnumerable<Customer>>();
        }

    }
}

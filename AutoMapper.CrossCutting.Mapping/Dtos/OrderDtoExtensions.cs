using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace AutoMapper.CrossCutting.Mapping.Dtos
{
    public static class OrderDtoExtensions
    {

        public static OrderDto ToModel(this Order entity)
        {
            return entity.MapTo<Order, OrderDto>();
        }

        public static IEnumerable<OrderDto> ToModel(this IEnumerable<Order> entity)
        {
            return entity.MapTo<IEnumerable<Order>, IEnumerable<OrderDto>>();
        }

        public static Order ToEntity(this OrderDto model)
        {
            return model.MapTo<OrderDto, Order>();
        }

        public static IEnumerable<Order> ToEntity(this IEnumerable<OrderDto> model)
        {
            return model.MapTo<IEnumerable<OrderDto>, IEnumerable<Order>>();
        }

    }
}

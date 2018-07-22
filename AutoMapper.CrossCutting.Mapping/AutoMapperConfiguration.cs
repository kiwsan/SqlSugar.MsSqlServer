using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace AutoMapper.CrossCutting.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {

                #region Post
                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(d => d.TableOrders, d => d.Ignore())
                ;
                cfg.CreateMap<OrderDto, Order>()
                    .ForMember(d => d.TableCustomer, d => d.Ignore())
                    .ForMember(d => d.TableOrderItems, d => d.Ignore())
                ;
                //cfg.CreateMap<ProductViewModel, Product>();
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }

    }
}

using Application.Interfaces;
using Autofac;
using Domain.Interfaces;
using Infrastructure.Uow;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.Startup;
using ViewModel.Dtos;

namespace UnitTestProject.Repositorys
{
    [TestFixture]
    public class CustomerRepositoryNUnitTest : NUnitTestBase
    {

        [TestCase("Maria", "Anders")]
        public void FindByName_Test(string firstName, string lastName)
        {
            var customerRepository = _container.Resolve<ICustomerRepository>();

            var objCustomer = customerRepository.FindByName(firstName, lastName);

            Assert.IsNotNull(objCustomer);

            Console.WriteLine($"FirstName: {objCustomer.FirstName} LastName: {objCustomer.LastName}");
            foreach (var order in objCustomer.TableOrders)
            {
                Console.WriteLine($"-OrderDate: {order.OrderDate}");
                Console.WriteLine($"-OrderNumber: {order.OrderNumber}");
                Console.WriteLine($"-TotalAmount: {order.TotalAmount}");
                Console.WriteLine($"------------------");
            }
        }

        [TestCase(1)]
        public void FindById_Test(int id)
        {

            var unitOfWork = _container.Resolve<IUnitOfWork>();
            var customerRepository = _container.Resolve<ICustomerRepository>();

            unitOfWork.BeginTransaction();

            try
            {
                var objCustomer = customerRepository.FindById(id);

                Assert.IsNotNull(objCustomer);

                Console.WriteLine($"FirstName: {objCustomer.FirstName} LastName: {objCustomer.LastName}");
                foreach (var order in objCustomer.TableOrders)
                {
                    Console.WriteLine($"------------------");
                    Console.WriteLine($"-OrderDate: {order.OrderDate}");
                    Console.WriteLine($"-OrderNumber: {order.OrderNumber}");
                    Console.WriteLine($"-TotalAmount: {order.TotalAmount}");
                }

                unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();

                throw ex;
            }
        }

        [Test]
        public void AddCustomerAndOrders_Test()
        {

            var customerService = _container.Resolve<ICustomerService>();

            var objNewOrders = new List<OrderDto>();
            var objNewOrder1 = new OrderDto(DateTime.UtcNow, "X-12055", 23.22m);
            var objNewOrder2 = new OrderDto(DateTime.UtcNow, "X-6521C", 52.89m);
            var objNewOrder3 = new OrderDto(DateTime.UtcNow, "X-5SC23", 112.34m);

            objNewOrders.Add(objNewOrder1);
            objNewOrders.Add(objNewOrder2);
            objNewOrders.Add(objNewOrder3);

            var objNewCustomerDto = new CustomerDto("Elizabeth3", "Lily3", "Thailand", "Bangkok", "000-855-1252", objNewOrders);

            var objCustomerDto = customerService.Add(objNewCustomerDto);
            Console.WriteLine($"Id: {objCustomerDto.Id}");
            Console.WriteLine($"FirstName: {objCustomerDto.FirstName}");
            Console.WriteLine($"LastName: {objCustomerDto.LastName}");
            Console.WriteLine($"City: {objCustomerDto.City}");
            Console.WriteLine($"Country: {objCustomerDto.Country}");
            Console.WriteLine($"Phone: {objCustomerDto.Phone}");
            foreach (var order in objCustomerDto.TableOrderDtos)
            {
                Console.WriteLine($"------------------");
                Console.WriteLine($"-Id: {order.Id}");
                Console.WriteLine($"-OrderDate: {order.OrderDate}");
                Console.WriteLine($"-OrderNumber: {order.OrderNumber}");
                Console.WriteLine($"-TotalAmount: {order.TotalAmount}");
            }
        }

    }
}

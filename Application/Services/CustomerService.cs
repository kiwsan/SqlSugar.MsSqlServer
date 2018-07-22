using Application.Interfaces;
using AutoMapper.CrossCutting.Mapping.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        public CustomerService(IOrderRepository _orderRepository,
                               ICustomerRepository _customerRepository,
                               IUnitOfWork _unitOfWork)
        {
            this._orderRepository = _orderRepository;
            this._customerRepository = _customerRepository;
            this._unitOfWork = _unitOfWork;
        }

        public CustomerDto Add(CustomerDto command)
        {

            var objNewCustomer = command.ToEntity();
            var objNewOrders = command.TableOrderDtos.ToEntity();
            try
            {
                _unitOfWork.BeginTransaction();

                var existingWithSameName = _customerRepository.FindByName(command.FirstName, command.LastName);
                if (existingWithSameName != null)
                {
                    throw new Exception("User already exists with this name");
                }

                command.Id = (int)_customerRepository.Insert(objNewCustomer);

                _orderRepository.AddRang(command.Id, objNewOrders);

                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();

                throw ex;
            }

            var objNewOrdersCommand = objNewOrders.ToModel();

            return new CustomerDto(command.Id, command.FirstName,
                command.LastName, command.City,
                command.Country, command.Phone, objNewOrdersCommand.ToList());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

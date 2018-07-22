using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace Application.Interfaces
{
    public interface ICustomerService : IDisposable
    {

        CustomerDto Add(CustomerDto command);

    }
}

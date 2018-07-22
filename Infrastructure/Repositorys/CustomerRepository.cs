using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Customer FindByName(string firstName, string lastName)
        {
            return FindByClause(g => g.FirstName == firstName && g.LastName == lastName);
        }

    }
}

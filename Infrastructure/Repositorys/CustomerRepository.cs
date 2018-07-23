using Domain;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Factorys;
using SqlSugar;
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

        protected override string ConnectionString { get; set; }
        protected override DbType? DatabaseType { get; set; }

        public Customer FindByName(string firstName, string lastName)
        {
            ConnectionString = Constants.ConnectionString;
            DatabaseType = DbType.SqlServer;

            return FindByClause(g => g.FirstName == firstName && g.LastName == lastName);
        }

    }
}

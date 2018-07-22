using Infrastructure.Factorys;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Uow
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDbFactory _dbFactory;
        private SqlSugarClient _dbContext;
        public UnitOfWork(IDbFactory _dbFactory)
        {
            this._dbFactory = _dbFactory;
        }

        public SqlSugarClient DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void BeginTransaction()
        {
            DbContext.Ado.BeginTran();
        }

        public void CommitTransaction()
        {
            DbContext.Ado.CommitTran();
        }

        public void RollbackTransaction()
        {
            DbContext.Ado.RollbackTran();
        }

    }
}

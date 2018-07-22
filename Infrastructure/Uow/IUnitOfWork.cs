using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Uow
{
    public interface IUnitOfWork
    {

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

    }
}

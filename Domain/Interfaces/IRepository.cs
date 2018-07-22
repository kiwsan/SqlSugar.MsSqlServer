using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {

        T FindById(object pkValue);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "");

        T FindByClause(Expression<Func<T, bool>> predicate);

        long Insert(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool Delete(Expression<Func<T, bool>> @where);

        bool DeleteById(object id);

        bool DeleteByIds(object[] ids);

        IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20);

    }
}

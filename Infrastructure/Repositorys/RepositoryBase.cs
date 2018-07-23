using Domain.Interfaces;
using Infrastructure.Factorys;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorys
{

    public abstract class RepositoryBase<T> : IRepository<T> where T : class, new()
    {

        protected abstract string ConnectionString { get; set; }
        protected abstract DbType? DatabaseType { get; set; }

        private SqlSugarClient dataContext;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected SqlSugarClient DbContext
        {
            get
            {
                bool isNewConfig = !string.IsNullOrEmpty(ConnectionString) && DatabaseType.HasValue;

                if (dataContext == null || isNewConfig)
                {
                    return dataContext = DbFactory.Init(ConnectionString, DatabaseType);
                }

                return dataContext;
            }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public T FindById(object pkValue)
        {
            return DbContext.Queryable<T>().InSingle(pkValue);
        }

        public IEnumerable<T> FindAll()
        {
            return DbContext.Queryable<T>().ToList();
        }

        public IEnumerable<T> FindListByClause(Expression<Func<T, bool>> predicate, string orderBy = "")
        {
            var query = DbContext.Queryable<T>().Where(predicate);
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            return query.ToList();
        }

        public T FindByClause(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Queryable<T>().First(predicate);
        }

        public long Insert(T entity)
        {
            return DbContext.Insertable(entity).ExecuteReturnBigIdentity();
        }

        public bool Update(T entity)
        {
            var i = DbContext.Updateable(entity).ExecuteCommand();
            return i > 0;
        }

        public bool Delete(T entity)
        {
            var i = DbContext.Deleteable(entity).ExecuteCommand();
            return i > 0;
        }

        public bool Delete(Expression<Func<T, bool>> @where)
        {
            var i = DbContext.Deleteable<T>(@where).ExecuteCommand();
            return i > 0;
        }

        public bool DeleteById(object id)
        {
            var i = DbContext.Deleteable<T>(id).ExecuteCommand();
            return i > 0;
        }

        public bool DeleteByIds(object[] ids)
        {
            var i = DbContext.Deleteable<T>().In(ids).ExecuteCommand();
            return i > 0;
        }

        public IPagedList<T> FindPagedList(Expression<Func<T, bool>> predicate, string orderBy = "", int pageIndex = 1, int pageSize = 20)
        {
            var totalCount = 0;
            var page = DbContext.Queryable<T>().OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref totalCount);
            var list = new PagedList<T>(page, pageIndex, pageSize, totalCount);
            return list;
        }

    }
}

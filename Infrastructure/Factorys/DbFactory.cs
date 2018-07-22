using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using SqlSugar;

namespace Infrastructure.Factorys
{
    public class DbFactory : IDbFactory
    {

        private SqlSugarClient _sqlSugarClient;
        public SqlSugarClient Init()
        {
            return _sqlSugarClient ?? (_sqlSugarClient = new SqlSugarClient(Configure));
        }

        private ConnectionConfig _configure;
        private ConnectionConfig Configure
        {
            get
            {
                return _configure ?? (_configure = new ConnectionConfig()
                {
                    ConnectionString = Constants.ConnectionString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    IsShardSameThread = true
                });
            }
        }

        private bool isDisposed;

        ~DbFactory()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (_sqlSugarClient != null)
                    _sqlSugarClient.Dispose();
            }

            isDisposed = true;
        }

    }
}

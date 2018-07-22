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

        SqlSugarClient sqlSugarClient;
        public SqlSugarClient Init()
        {
            if (sqlSugarClient != null)
            {
                return sqlSugarClient;
            }

            return new SqlSugarClient(Configure);
        }

        private ConnectionConfig Configure
        {
            get
            {
                return new ConnectionConfig()
                {
                    ConnectionString = Constants.ConnectionString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    IsShardSameThread = true
                };
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
                if (sqlSugarClient != null)
                    sqlSugarClient.Dispose();
            }

            isDisposed = true;
        }

    }
}

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
        public SqlSugarClient Init(string connectionString = "", DbType? databaseType = null)
        {

            //default connection
            if (string.IsNullOrEmpty(connectionString)) { connectionString = Constants.ConnectionString; }
            if (!databaseType.HasValue) { databaseType = DbType.SqlServer; }

            var connectionConfig = new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = (DbType)databaseType,
                IsAutoCloseConnection = true,
                IsShardSameThread = true
            };
            return _sqlSugarClient ?? (_sqlSugarClient = new SqlSugarClient(connectionConfig));
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

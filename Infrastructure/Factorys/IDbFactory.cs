using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factorys
{
    public interface IDbFactory : IDisposable
    {

        SqlSugarClient Init();

    }
}

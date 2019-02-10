using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Constants
    {

        public static string ConnectionString
        {
            get
            {
                return @"Server=localhost;Database=developer;User Id=sa;
Password=Str0ngPassword!;";
            }
        }

    }
}

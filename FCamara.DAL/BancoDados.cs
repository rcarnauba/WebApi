using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.DAL
{
    public class BancoDados
    {
        private static readonly string _connectionString = "Data Source=DESKTOP-MJMDVC3\\SQLEXPRESS;Initial Catalog=FCamara;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}

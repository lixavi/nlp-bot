using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            //var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
            //SqlConnection con = new SqlConnection($"Data Source={dbhost};Initial Catalog=db_pkversity;User ID=sa;Password=awab123@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30");
             //SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=db_pkversity;Integrated Security=True");
            SqlConnection con = new SqlConnection(@"Data Source=65.108.97.18;Initial Catalog=db_pkversity; User ID=user_pkversity; password=y^7R7lv28");
            // SqlConnection con = new SqlConnection(@"Data Source=pkversity.database.windows.net;Initial Catalog=db_pkversity;User ID=db_pkversity;Password=earthandworld.985;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //SqlConnection con = new SqlConnection(@"Server=tcp:pktrip.database.windows.net,1433;Initial Catalog=db_pkversity;Persist Security Info=False;User ID=pkadmin;Password=SAAD@aashir;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return con;

        }

    }
}
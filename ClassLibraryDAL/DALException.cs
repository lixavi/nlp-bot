using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassLibraryEntities;

namespace ClassLibraryDAL
{
    public class DALException
    {

        public static List<EntException> GetException()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("A_SP_GetError", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntException> CitiesList = new List<EntException>();
            while (sdr.Read())
            {
                EntException ee = new EntException();
                ee.DateTime = sdr["DateTime"].ToString();
                ee.Exception = sdr["Exception"].ToString();
                CitiesList.Add(ee);
            }
            con.Close();
            return CitiesList;
        }

    }
}

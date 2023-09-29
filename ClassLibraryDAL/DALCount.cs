using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DALCount
    {
        public static EntCount GetCount()
        {
            EntCount ee = new EntCount();
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetTableCounts", con);
               
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    ee.CitiesCount = sdr["CitiesCount"].ToString();
                    ee.InstCount = sdr["InstCount"].ToString();
                    ee.PD = sdr["PD"].ToString();
                    ee.PassingDSGroups = sdr["PassingDSGroups"].ToString();
                    ee.ProgramDegrees = sdr["ProgramDegrees"].ToString();
                    ee.UserInfo = sdr["UserInfo"].ToString();
                    ee.Subjects = sdr["Subjects"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }
            return ee;
        }
        public static string? Excep { get; set; }
        public static void GetError(string Err)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_StoreError", con);
            cmd.Parameters.AddWithValue("@Err", Err);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryEntities;
namespace ClassLibraryDAL
{ 
    public class DALUserAcountService
    {
        public static string? Excep { get; set; }


        public static EntInstitutes GetUserByName(string UserName)
        {
            EntInstitutes ee = new EntInstitutes();

            try
            {


                SqlConnection con = ClassLibraryDAL.DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetUserByName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.InstituteId = sdr["InstituteId"].ToString();
                    ee.UserName = sdr["UserName"].ToString();
                    ee.Password = sdr["Password"].ToString();


                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return ee;

        }
        public static void SaveRegisterFrom(EntInstitutes ee)
        {
            try
            {


                SqlConnection con = ClassLibraryDAL.DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveRegistrationForm", con);
                cmd.Parameters.AddWithValue("@Name", ee.UserName);

                cmd.Parameters.AddWithValue("Password", ee.Password);
                cmd.Parameters.AddWithValue("Role", ee.Role);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
        }

    }
}

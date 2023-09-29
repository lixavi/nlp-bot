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
    public class DALUserLogin
    {
        public static string? Excep { get; set; }

        public static EntUserlogin GetUserByName(string? Email)
        {
            EntUserlogin ee = new EntUserlogin();

            try
            {


                SqlConnection con = ClassLibraryDAL.DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetUserByName", con);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.UserId = sdr["UserId"].ToString();
                    ee.Email = sdr["Email"].ToString();
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

        public static void SaveSignUp(EntUserlogin ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_SaveSignUp", con);
                cmd.Parameters.AddWithValue("@FirstName", ee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", ee.LastName);
                cmd.Parameters.AddWithValue("@Email", ee.Email);
                cmd.Parameters.AddWithValue("@Password", ee.Password);
                cmd.Parameters.AddWithValue("@ContactNo", ee.ContactNo);
                cmd.Parameters.AddWithValue("@City", ee.City);
                cmd.Parameters.AddWithValue("@Gender", ee.Gender);
                cmd.Parameters.AddWithValue("@Role", ee.Role);
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

        public static void UpdatePassword(String? UserId, String? Password)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_UpdatePassword", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex) 
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
        }
    }
}

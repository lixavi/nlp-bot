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
    public class DalInstitutes
    {
        public static string? Excep { get; set; }

        public static List<EntInstitutes> GetInstitutes()
        {
            List<EntInstitutes> instituteList = new List<EntInstitutes>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetInstitutes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntInstitutes ee = new EntInstitutes();
                    ee.@InstituteId = sdr["InstituteId"].ToString();
                    ee.@Title = sdr["Title"].ToString();
                    ee.@Email = sdr["Email"].ToString();
                    ee.@Phone = sdr["Phone"].ToString();
                    ee.@UserName = sdr["UserName"].ToString();
                    ee.@Password = sdr["Password"].ToString();
                    ee.@CreatedOn = sdr["CreatedOn"].ToString();
                    ee.@IsActive = sdr["IsActive"].ToString();
                    ee.@CityId = sdr["CityId"].ToString();
                    ee.@TypeOfId = sdr["TypeOfId"].ToString();
                    ee.@Location = sdr["Location"].ToString();
                    ee.@AdminId = sdr["AdminId"].ToString();
                    ee.@admission_open_close = (bool?)sdr["admission_open_close"];
                    instituteList.Add(ee);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return instituteList;
        }


        public static EntInstitutes GetInstituteBtId(string? InstituteId)
        {
            EntInstitutes ee = new EntInstitutes();
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetInstituteBtId", con);
                cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
               
                while (sdr.Read())
                {
                    ee.InstituteId = sdr["InstituteId"].ToString();
                    ee.Title = sdr["Title"].ToString();
                    ee.Email = sdr["Email"].ToString();
                    ee.Phone = sdr["Phone"].ToString();
                    
                    ee.UserName = sdr["UserName"].ToString();
                    ee.Password = sdr["Password"].ToString();
                    ee.CreatedOn = sdr["CreatedOn"].ToString();
                    ee.IsActive = sdr["IsActive"].ToString();
                    ee.CityId = sdr["CityId"].ToString();
                    ee.TypeOfId = sdr["TypeOfId"].ToString();
                    ee.Location = sdr["Location"].ToString();
                    ee.AdminId = sdr["AdminId"].ToString();
                    ee.admission_open_close = (bool?)sdr["admission_open_close"];
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


        public static void SaveInstitutes(EntInstitutes ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveInstitutes", con);
                cmd.Parameters.AddWithValue("@Title", ee.Title);
                cmd.Parameters.AddWithValue("@Email", ee.Email);
                cmd.Parameters.AddWithValue("@Phone", ee.Phone);
                cmd.Parameters.AddWithValue("@UserName", ee.UserName);
                cmd.Parameters.AddWithValue("@Password", ee.Password);
                cmd.Parameters.AddWithValue("@CityId", ee.CityId);
                cmd.Parameters.AddWithValue("@TypeOfId", ee.TypeOfId);
                cmd.Parameters.AddWithValue("@Location", ee.Location);
                cmd.Parameters.AddWithValue("@AdminId", 1234);
                cmd.Parameters.AddWithValue("@admission_open_close", ee.admission_open_close);
                cmd.Parameters.AddWithValue("@logo", ee.Logo);

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

        public static void SaveAdmissionInfo(bool? value,string? InstituteId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                          
                SqlCommand cmd = new SqlCommand("A_SP_SaveAdmissionInfo", con);
                cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
                cmd.Parameters.AddWithValue("@admission_open_close", value);
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

        public static void DeleteInstitutes(string InstituteId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteInstitutes", con);
                cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
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


        public static void UpdateInstitutes(EntInstitutes ee)
        {
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateInstitute", con);
                cmd.Parameters.AddWithValue("@InstituteId", ee.InstituteId);
                cmd.Parameters.AddWithValue("@Title", ee.Title);
                cmd.Parameters.AddWithValue("@Email", ee.Email);
                cmd.Parameters.AddWithValue("@Phone", ee.Phone);
                cmd.Parameters.AddWithValue("@UserName", ee.UserName);
                cmd.Parameters.AddWithValue("@Password", ee.Password);
                cmd.Parameters.AddWithValue("@CreatedOn", ee.CreatedOn);
                cmd.Parameters.AddWithValue("@IsActive", ee.IsActive);
                cmd.Parameters.AddWithValue("@CityId", ee.CityId);
                cmd.Parameters.AddWithValue("@TypeOfId", ee.TypeOfId);
                cmd.Parameters.AddWithValue("@Location", ee.Location);
                cmd.Parameters.AddWithValue("@AdminId", ee.AdminId);
                cmd.Parameters.AddWithValue("@logo", ee.Logo);
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

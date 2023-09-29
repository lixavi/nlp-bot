using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DALEducationalInfo
    {
        public static string? Excep { get; set; }
        public static List<EntEducationalInfo> GetMatricInfo(string? id)
        {
            List<EntEducationalInfo> MatricList = new List<EntEducationalInfo>();
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetMatric", con);
                cmd.Parameters.AddWithValue("@SID", id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
            EntEducationalInfo ee = new EntEducationalInfo();
                    
                    ee.SID = sdr["SID"].ToString();
                    ee.PassingDSGroup = sdr["PassingDSGroup"].ToString();
                    ee.Board_University = sdr["Board_University"].ToString();
                    ee.ObtainedMarks = sdr["ObtainedMarks"].ToString();
                    ee.TotalMarks = sdr["TotalMarks"].ToString();
                    ee.Percentage = sdr["Percentage"].ToString();
                    ee.PassingYear = sdr["PassingYear"].ToString();
                    ee.Institute = sdr["Institute"].ToString();
                    MatricList.Add(ee);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return MatricList;
        }

        public static EntEducationalInfo GetMatricInfobyID(string? id)
        {
            List<EntEducationalInfo> MatricList = new List<EntEducationalInfo>();
            EntEducationalInfo ee = new EntEducationalInfo();
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetMatric", con);
                cmd.Parameters.AddWithValue("@SID", id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    ee.SID = sdr["SID"].ToString();
                    ee.PassingDSGroup = sdr["PassingDSGroup"].ToString();
                    ee.Board_University = sdr["Board_University"].ToString();
                    ee.ObtainedMarks = sdr["ObtainedMarks"].ToString();
                    ee.TotalMarks = sdr["TotalMarks"].ToString();
                    ee.Percentage = sdr["Percentage"].ToString();
                    ee.PassingYear = sdr["PassingYear"].ToString();
                    ee.Institute = sdr["Institute"].ToString();
                    MatricList.Add(ee);
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

        public static List<EntEducationalInfo> GetFscInfo(string? id)
        {
            List<EntEducationalInfo> FscList = new List<EntEducationalInfo>();

            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetFsc", con);
                cmd.Parameters.AddWithValue("@SID", id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntEducationalInfo ee = new EntEducationalInfo();
                    ee.SID = sdr["SID"].ToString();
                    ee.PassingDSGroup = sdr["PassingDSGroup"].ToString();
                    ee.Board_University = sdr["Board_University"].ToString();
                    ee.ObtainedMarks = sdr["ObtainedMarks"].ToString();
                    ee.TotalMarks = sdr["TotalMarks"].ToString();
                    ee.Percentage = sdr["Percentage"].ToString();
                    ee.PassingYear = sdr["PassingYear"].ToString();
                    ee.Institute = sdr["Institute"].ToString();
                    FscList.Add(ee);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return FscList;
        }
        public static EntEducationalInfo GetFscInfoByID(string? id)
        {
            List<EntEducationalInfo> FscList = new List<EntEducationalInfo>();

                    EntEducationalInfo ee = new EntEducationalInfo();
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetFsc", con);
                cmd.Parameters.AddWithValue("@SID", id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.SID = sdr["SID"].ToString();
                    ee.PassingDSGroup = sdr["PassingDSGroup"].ToString();
                    ee.Board_University = sdr["Board_University"].ToString();
                    ee.ObtainedMarks = sdr["ObtainedMarks"].ToString();
                    ee.TotalMarks = sdr["TotalMarks"].ToString();
                    ee.Percentage = sdr["Percentage"].ToString();
                    ee.PassingYear = sdr["PassingYear"].ToString();
                    ee.Institute = sdr["Institute"].ToString();
                    FscList.Add(ee);
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
        public static void SaveStdMatricInfo(EntEducationalInfo ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveStdMatric", con);
                cmd.Parameters.AddWithValue("@SID", ee.SID);
                cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
                cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
                cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
                cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
                cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
                cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
                cmd.Parameters.AddWithValue("@Institute", ee.Institute);
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
        public static void SaveStdFscInfo(EntEducationalInfo ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveStdFsc", con);
                cmd.Parameters.AddWithValue("@SID", ee.SID);
                cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
                cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
                cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
                cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
                cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
                cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
                cmd.Parameters.AddWithValue("@Institute", ee.Institute);
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

        public static void DeleteMatric(string id)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteMatric", con);
                cmd.Parameters.AddWithValue("@SID", id);
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

        public static void DeleteFsc(string id)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteFsc", con);
                cmd.Parameters.AddWithValue("@SID", id);
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

        public static void updateMatricInfo(EntEducationalInfo ee)
        {
            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_UpdateMatricInfo", con);
                cmd.Parameters.AddWithValue("@SID", ee.SID);
                cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
                cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
                cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
                cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
                cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
                cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
                cmd.Parameters.AddWithValue("@Institute", ee.Institute);
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

        public static void updateFSCInfo(EntEducationalInfo ee)
        {
            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_UpdateFSCInfo", con);
                cmd.Parameters.AddWithValue("@SID", ee.SID);
                cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
                cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
                cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
                cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
                cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
                cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
                cmd.Parameters.AddWithValue("@Institute", ee.Institute);
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

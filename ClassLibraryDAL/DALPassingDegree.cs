using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntities;

namespace ClassLibraryDAL
{
    public class DALPassingDegree
    {
        public static string? Excep { get; set; }
    
        public static void SavePassingdegrees(EntPassingDegree ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SavePassingDegrees", con);
                cmd.Parameters.AddWithValue("@Title", ee.Title);
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


        public static EntPassingDegree GetPassingDegreesById(string PassingDegreeId)
        {
            EntPassingDegree ee = new EntPassingDegree();

            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetpassingDegreesById", con);
                cmd.Parameters.AddWithValue("@PassingDegreesId", PassingDegreeId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.PassingDegreesId = sdr["PassingDegreeId"].ToString();
                    ee.Title = sdr["Title"].ToString();
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


        public static void UpdatePassingDegrees(EntPassingDegree ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdatePassingDegree", con);
                cmd.Parameters.AddWithValue("@id ", ee.PassingDegreesId);
                cmd.Parameters.AddWithValue("@Title", ee.Title);
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

        public static List<EntPassingDegree> GetPassingDegrees()
        {
            List<EntPassingDegree> PassingDegreesList = new List<EntPassingDegree>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetPassingDegrees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntPassingDegree ee = new EntPassingDegree();
                    ee.PassingDegreesId = sdr["PassingDegreeId"].ToString();
                    ee.Title = sdr["Title"].ToString();

                    PassingDegreesList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return PassingDegreesList;
        }


        public static void DeletePassingDegrees(string PassingDegreeId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeletePassingDegrees", con);
                cmd.Parameters.AddWithValue("@PassingDegreeId", PassingDegreeId);
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




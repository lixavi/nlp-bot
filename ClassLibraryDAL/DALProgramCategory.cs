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
    public class DALProgramCategory
    {
        public static string? Excep { get; set; }

        public static List<EntProgramCategory> GetProgramCategory()
        {
            List<EntProgramCategory> ProgramCategoryList = new List<EntProgramCategory>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetProgramCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntProgramCategory ee = new EntProgramCategory();
                    ee.ProgramCategoryId = sdr["ProgramCategoryId"].ToString();
                    ee.CategoryName = sdr["CategoryName"].ToString();

                    ProgramCategoryList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return ProgramCategoryList;
        }

        public static void SaveProgramCategory(EntProgramCategory ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveProgramCategory", con);

                cmd.Parameters.AddWithValue("@CategoryName", ee.CategoryName);

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

        public static void DeleteProgramCategory(string ProgramCategoryId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteProgramCategory", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(ProgramCategoryId));
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

        public static void UpdateProgramCategory(EntProgramCategory ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateProgramCategory", con);
                cmd.Parameters.AddWithValue("@ProgramCategoryId", ee.ProgramCategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", ee.CategoryName);

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

        public static EntProgramCategory GetProgramCategoryById(string CategoryID)
        {
            EntProgramCategory ee = new EntProgramCategory();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AddCategoryWithID", con);
                cmd.Parameters.AddWithValue("@CAID", int.Parse(CategoryID));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.ProgramCategoryId = sdr["ProgramCategoryId"].ToString();
                    ee.CategoryName = sdr["CategoryName"].ToString();

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
    }
}

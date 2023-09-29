using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryDAL;
using ClassLibraryEntities;


namespace ClassLibraryDAL
{
    public class DALFutureScope
    {    
        public static string? Excep { get; set; }

        public static void SaveDesciption(EntFutureScope ee)
        {   
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveDescription", con);
                cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
                cmd.Parameters.AddWithValue("@Description", ee.Description);
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

        public static void UpdateDesciption(EntFutureScope ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateDescription", con);
                cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
                cmd.Parameters.AddWithValue("@Description", ee.Description);
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

        public static List<EntFutureScope> GetFutureScopeById(string ProgramDegreeId)
        {
            List<EntFutureScope> FutureList = new List<EntFutureScope>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetFutureScopeById", con);
                cmd.Parameters.AddWithValue("@ProgramDegreeId", int.Parse(ProgramDegreeId));  //
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntFutureScope ee = new EntFutureScope();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    ee.Description = sdr["Description"].ToString();
                    FutureList.Add(ee);
                }
                con.Close();

            }
              catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return FutureList;

        }

    }
}

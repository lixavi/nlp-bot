using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntities;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibraryDAL
{
    public class DALPassingDSGroups
    {
        public static string? Excep { get; set; }

        public static void SavePassingDSGroups(EntPassingDSGroups ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SavePassingDSGroups", con);
                cmd.Parameters.AddWithValue("@PassingDSGroups", ee.PassingDSGroups);
                cmd.Parameters.AddWithValue("@PassingDegreeId", ee.PassingDegreeId);
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

        public static EntPassingDSGroups GetPassingDSGroupsById(string PassingDSGroupsId)
        {
            EntPassingDSGroups ee = new EntPassingDSGroups();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetpassingDSGroupsById", con);
                cmd.Parameters.AddWithValue("@PassingDSGroupsId", PassingDSGroupsId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.PassingDSGroupsId = sdr["PassingDSGroupsId"].ToString();
                    ee.PassingDSGroups = sdr["PassingDSGroups"].ToString();
                    ee.PassingDegreeId = sdr["PassingDegreeId"].ToString();

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

        public static void UpdatePassingDSGroups(EntPassingDSGroups ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdatePassingDSGroups", con);
                cmd.Parameters.AddWithValue("@PassingDSGroupsId ", ee.PassingDSGroupsId);
                cmd.Parameters.AddWithValue("@PassingDSGroups ", ee.PassingDSGroups);
                cmd.Parameters.AddWithValue("@PassingDegreeId", ee.PassingDegreeId);
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

        public static void DeletePassingDSGroups(string PassingDSGroupsId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeletePassingDSGroups", con);
                cmd.Parameters.AddWithValue("@PassingDSGroupsId", int.Parse(PassingDSGroupsId));
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


        public static List<EntPassingDSGroups> GetPassingDSGroups()
        {
            List<EntPassingDSGroups> PassingDSGroupsList = new List<EntPassingDSGroups>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetPassingDSGroups", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntPassingDSGroups ee = new EntPassingDSGroups();
                    ee.PassingDegreeId = sdr["PassingDegreeId"].ToString();
                    ee.PassingDSGroups = sdr["PassingDSGroups"].ToString();
                    ee.PassingDSGroupsId = sdr["PassingDSGroupsId"].ToString();

                    PassingDSGroupsList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return PassingDSGroupsList;
        }
        public static List<EntPassingDSGroups> GetGroupsById(string ID, int InstituteId)
        {
            List<EntPassingDSGroups> passingDSGroupsList = new List<EntPassingDSGroups>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetProgramGroupsBYID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(ID));
                cmd.Parameters.AddWithValue("@InstituteId", InstituteId);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntPassingDSGroups ee = new EntPassingDSGroups();
                    ee.PassingDSGroupsId = sdr["value"].ToString();
                    ee.PassingDSGroups = sdr["PassingDSGroups"].ToString();
                    passingDSGroupsList.Add(ee);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return passingDSGroupsList;
        }


    }
}

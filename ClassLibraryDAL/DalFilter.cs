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
    public class DalFilter
    {


       

        public static List<EntFilterUniversity> GetResultByid(string PDSGID)
        {
            List<EntFilterUniversity> FilterList = new List<EntFilterUniversity>();
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetResultById", con);
                cmd.Parameters.AddWithValue("@PDSGID", PDSGID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    EntFilterUniversity ee = new EntFilterUniversity();
                    ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                    ee.Title = sdr["Title"].ToString();
                    ee.InstituteId = sdr["InstituteId"].ToString();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    ee.DegreeName = sdr["DegreeName"].ToString();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    ee.CityId = sdr["CityId"].ToString();
                    ee.CityName = sdr["CityName"].ToString();
                    
                    FilterList.Add(ee);

                }
                con.Close();
               
            }
            catch(Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }
            return FilterList;
        }
        public static List<EntFilterUniversity> GetDepartmentsbyID(string PDSGID, string CityId, string Percentage)
        {
            List<EntFilterUniversity> FilterList = new List<EntFilterUniversity>();
            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetDepartmentCountByGroupIdAndCityId", con);
                cmd.Parameters.AddWithValue("@PDSGID", PDSGID);
                cmd.Parameters.AddWithValue("@CityId", int.Parse(CityId));
                cmd.Parameters.AddWithValue("@Percentage", int.Parse(Percentage));
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    EntFilterUniversity ee = new EntFilterUniversity();

                    ee.Title = sdr["Title"].ToString();
                    ee.InstituteId = sdr["InstituteId"].ToString();
                    ee.Departments = sdr["Departments"].ToString();
                    ee.admission_Open_Close = (bool?)sdr["admission_open_close"];
                    ee.logo = sdr["logo"].ToString();

                    FilterList.Add(ee);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);

            }


            return FilterList;
        }

        public static List<EntProgramDegreeDetails> GetDepartmentDetailsbyID(string PDSGID, string InstituteID)
        {
            List<EntProgramDegreeDetails> DepartmentList = new List<EntProgramDegreeDetails>();
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetDepartmentDetails", con);
                cmd.Parameters.AddWithValue("@PDSGID", PDSGID);
                cmd.Parameters.AddWithValue("@InstituteID", int.Parse(InstituteID));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    EntProgramDegreeDetails ee = new EntProgramDegreeDetails();
                    ee.Duration = sdr["Duration"].ToString();
                    ee.Matric = sdr["SemesterFee"].ToString();
                    ee.FSC = sdr["FSC"].ToString();
                    ee.Matric = sdr["Matric"].ToString();
                    ee.TotalFee = sdr["TotalFee"].ToString();
                    ee.SemesterFee = sdr["SemesterFee"].ToString();
                    ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                    ee.DegreeName = sdr["DegreeName"].ToString();
                    ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    DepartmentList.Add(ee);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }
            return DepartmentList;
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




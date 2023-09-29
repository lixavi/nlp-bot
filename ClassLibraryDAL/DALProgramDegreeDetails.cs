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
    public class DALProgramDegreeDetails
    {
        public static string? Excep { get; set; }

        public static List<EntProgramDegreeDetails> GetProgramDegreeDetails()
        {
            List<EntProgramDegreeDetails> ProgramDegreeDetailList = new List<EntProgramDegreeDetails>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetProgramDegreeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntProgramDegreeDetails ee = new EntProgramDegreeDetails();


                    ee.ProgramDegreeDetailsId = sdr["ProgramDegreeDetailsId"].ToString();
                    ee.Programs = sdr["Programs"].ToString();
                    ee.Duration = sdr["Duration"].ToString();
                    ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                    ee.Matric = sdr["Matric"].ToString();
                    ee.FSC = sdr["FSC"].ToString();
                    ee.BS = sdr["BS"].ToString();
                    ee.TotalFee = sdr["TotalFee"].ToString();
                    ee.SemesterFee = sdr["SemesterFee"].ToString();
                    ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                    ee.ApprovedById = sdr["ApprovedById"].ToString();
                    ee.Morning = (bool)sdr["Morning"];
                    ee.Evening = (bool)sdr["Evening"];
                    ee.Weekened = (bool)sdr["Weekened"];
                    ee.CityId = sdr["CityId"].ToString();
                    ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    ee.InstituteId = sdr["InstituteId"].ToString();

                    ProgramDegreeDetailList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return ProgramDegreeDetailList;
        }


        public static List<EntProgramDegreeDetails> GetProgramDegreeDetailsByInstituteId(string InstituteId)
            {
            List<EntProgramDegreeDetails> ProgramDegreeDetailList = new List<EntProgramDegreeDetails>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetProgramDegreeDetailsByInstituteId", con);
                cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntProgramDegreeDetails ee = new EntProgramDegreeDetails();


                    ee.ProgramDegreeDetailsId = sdr["ProgramDegreeDetailsId"].ToString();
                    ee.Programs = sdr["Programs"].ToString();
                    ee.Duration = sdr["Duration"].ToString();
                    ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                    ee.Matric = sdr["Matric"].ToString();
                    ee.FSC = sdr["FSC"].ToString();
                    ee.BS = sdr["BS"].ToString();
                    ee.TotalFee = sdr["TotalFee"].ToString();
                    ee.SemesterFee = sdr["SemesterFee"].ToString();
                    ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                    ee.ApprovedById = sdr["ApprovedById"].ToString();
                    ee.Morning = (bool)sdr["Morning"];
                    ee.Evening = (bool)sdr["Evening"];
                    ee.Weekened = (bool)sdr["Weekened"];
                    ee.CityId = sdr["CityId"].ToString();
                    ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                    ee.DegreeName = sdr["DegreeName"].ToString();
                    ee.ProgramDegreeId = sdr["DegreeName"].ToString();

                    ee.InstituteId = sdr["InstituteId"].ToString();

                    ProgramDegreeDetailList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return ProgramDegreeDetailList;
        }
        //[ProgramDegreeDetailsId], [Duration], [TotalSemesters], [TotalFee], [SemesterFee], [ApprovedById], [CityId], [Morning], [Evening], [Weekened],
        //[PassingDegreeGroups], [ProgramDegreeId], [InstituteId], [Percentage]
        public static void SaveProgramDegreeDetails(EntProgramDegreeDetails ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveProgramDegreeDetails", con);
                cmd.Parameters.AddWithValue("@Duration", ee.Duration);
                cmd.Parameters.AddWithValue("@TotalSemesters", ee.TotalSemesters);
                cmd.Parameters.AddWithValue("@TotalFee", ee.TotalFee);
                cmd.Parameters.AddWithValue("@SemesterFee", ee.SemesterFee);
                cmd.Parameters.AddWithValue("@ClosingMerit", ee.ClosingMerit);
                cmd.Parameters.AddWithValue("@ApprovedById", ee.ApprovedById);
                cmd.Parameters.AddWithValue("@CityId", ee.CityId);
                cmd.Parameters.AddWithValue("@Morning", ee.Morning);
                cmd.Parameters.AddWithValue("@Evening", ee.Evening);
                cmd.Parameters.AddWithValue("@Weekened", ee.Weekened);
                cmd.Parameters.AddWithValue("@PassingDegreeGroups", ee.PassingDegreeGroups);
                cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
                cmd.Parameters.AddWithValue("@InstituteId", int.Parse(ee.InstituteId));


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

        public static void DeleteProgramDegreeDetails(string ProgramDegreeDetailsId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteProgramDegreeDetails", con);
                cmd.Parameters.AddWithValue("@ProgramDegreeDetailsId", int.Parse(ProgramDegreeDetailsId));
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
        public static void UpdateProgramCategory(EntProgramDegreeDetails ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateProgramDegreeDetails", con);
                cmd.Parameters.AddWithValue("@ProgramDegreeDetailsId", int.Parse(ee.ProgramDegreeDetailsId));
                cmd.Parameters.AddWithValue("@Duration", ee.Duration);
                cmd.Parameters.AddWithValue("@TotalSemesters", ee.TotalSemesters);
                cmd.Parameters.AddWithValue("@TotalFee", ee.TotalFee);
                cmd.Parameters.AddWithValue("@SemesterFee", ee.SemesterFee);
                cmd.Parameters.AddWithValue("@ClosingMerit", ee.ClosingMerit);
                cmd.Parameters.AddWithValue("@ApprovedById", ee.ApprovedById);
                cmd.Parameters.AddWithValue("@Matric", ee.Matric);
                cmd.Parameters.AddWithValue("@FSC", ee.FSC);
                cmd.Parameters.AddWithValue("@BS", ee.BS);
                cmd.Parameters.AddWithValue("@CityId", ee.CityId);
                cmd.Parameters.AddWithValue("@Morning", ee.Morning);
                cmd.Parameters.AddWithValue("@Evening", ee.Evening);
                cmd.Parameters.AddWithValue("@Weekened", ee.Weekened);
                cmd.Parameters.AddWithValue("@type", ee.type);
                cmd.Parameters.AddWithValue("@PassingDegreeGroups", ee.PassingDegreeGroups);
                cmd.Parameters.AddWithValue("@ProgramDegreeId", ee.ProgramDegreeId);
                cmd.Parameters.AddWithValue("@InstituteId", ee.InstituteId);


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

        public static EntProgramDegreeDetails GetProgramDegreeDetailsByID(string ProgramDegreeDetailsId)
        {
            EntProgramDegreeDetails ee = new EntProgramDegreeDetails();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AddProgramDegreeDetailsById", con);
                cmd.Parameters.AddWithValue("@DDID", int.Parse(ProgramDegreeDetailsId));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {

                    ee.ProgramDegreeDetailsId = sdr["ProgramDegreeDetailsId"].ToString();
                    ee.Duration = sdr["Duration"].ToString();
                    ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                    ee.TotalFee = sdr["TotalFee"].ToString();
                    ee.SemesterFee = sdr["SemesterFee"].ToString();
                    ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                    ee.ApprovedById = sdr["ApprovedById"].ToString();
                    ee.CityId = sdr["CityId"].ToString();
                    ee.Morning = (bool)sdr["Morning"];
                    ee.Evening = (bool)sdr["Evening"];
                    ee.Weekened = (bool)sdr["Weekened"];
                    ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    ee.InstituteId = sdr["InstituteId"].ToString();

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

        public static List<EntProgramDegreeDetails> GetGroupsById(string ID, int InstituteId)
        {
                List<EntProgramDegreeDetails> passingDSGroupsList = new List<EntProgramDegreeDetails>();

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
                    EntProgramDegreeDetails ee = new EntProgramDegreeDetails();

                    ee.ProgramDegreeId = sdr["value"].ToString();
                    ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
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

        public static List<EntProgramDegreeDetails> GetProgramDegreeByInstituteId(string InstituteId)
        {
            List<EntProgramDegreeDetails> ProgramDegreeDetailList = new List<EntProgramDegreeDetails>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetProgramDegreeByInstituteId", con);
                cmd.Parameters.AddWithValue("@InstituteId", int.Parse(InstituteId));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntProgramDegreeDetails ee = new EntProgramDegreeDetails();


                    ee.ProgramDegreeDetailsId = sdr["ProgramDegreeDetailsId"].ToString();
                    ee.Programs = sdr["Programs"].ToString();
                    ee.Duration = sdr["Duration"].ToString();
                    ee.TotalSemesters = sdr["TotalSemesters"].ToString();
                    ee.Matric = sdr["Matric"].ToString();
                    ee.FSC = sdr["FSC"].ToString();
                    ee.BS = sdr["BS"].ToString();
                    ee.TotalFee = sdr["TotalFee"].ToString();
                    ee.SemesterFee = sdr["SemesterFee"].ToString();
                    ee.ClosingMerit = sdr["ClosingMerit"].ToString();
                    ee.ApprovedById = sdr["ApprovedById"].ToString();
                    ee.Morning = (bool)sdr["Morning"];
                    ee.Evening = (bool)sdr["Evening"];
                    ee.Weekened = (bool)sdr["Weekened"];
                    ee.CityId = sdr["CityId"].ToString();
                    ee.PassingDegreeGroups = sdr["PassingDegreeGroups"].ToString();
                    ee.ProgramDegreeId = sdr["ProgramDegreeId"].ToString();
                    ee.DegreeName = sdr["DegreeName"].ToString();
                    ee.InstituteId = sdr["InstituteId"].ToString();

                    ProgramDegreeDetailList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return ProgramDegreeDetailList;


        }

    }
}

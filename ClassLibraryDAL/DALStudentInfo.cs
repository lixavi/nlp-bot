using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassLibraryEntities;
using System.Reflection.Metadata;

namespace ClassLibraryDAL
{
    public class DALStudentInfo
    {


        public static string? Excep { get; set; }


        public static void SaveStudentInfo(EntStudentInfo ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveStudentInfo", con);
                cmd.Parameters.AddWithValue("@SID", ee.SID);
                cmd.Parameters.AddWithValue("@FirstName", ee.FirstName);
                cmd.Parameters.AddWithValue("@FatherName", ee.FatherName);
                cmd.Parameters.AddWithValue("@Gender", ee.Gender);
                cmd.Parameters.AddWithValue("@CNIC", ee.CNIC);
                cmd.Parameters.AddWithValue("@DateOfBirth", ee.DateOfBirth);
                cmd.Parameters.AddWithValue("@City", ee.City);
                cmd.Parameters.AddWithValue("@Address", ee.Address);
                cmd.Parameters.AddWithValue("@StudentMobileNo", ee.StudentMobileNo);
                cmd.Parameters.AddWithValue("@Email", ee.Email);
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


        public static List<EntStudentInfo> GetStudentInfobyID(string stdid)
        {
            List<EntStudentInfo> StudentInfoList = new List<EntStudentInfo>();

            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetStudentInfobyID", con);
                cmd.Parameters.AddWithValue("@StdId", stdid);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    EntStudentInfo ee = new EntStudentInfo();
                    ee.SID = sdr["SID"].ToString();
                    ee.FirstName = sdr["FirstName"].ToString();
                    ee.FatherName = sdr["FatherName"].ToString();
                    ee.CNIC = sdr["StdCnic"].ToString();
                    ee.DateOfBirth = sdr["DateOfBirth"].ToString();
                    ee.City = sdr["City"].ToString();
                    ee.Email = sdr["Email"].ToString();
                    ee.Gender = sdr["Gender"].ToString();
                    ee.StudentMobileNo = sdr["StdMobileNumber"].ToString();
                    StudentInfoList.Add(ee);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
            return StudentInfoList;

        }

        public static void DeleteStudentInfobyID(string id)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_DeleteStudentInfobyID", con);
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

        public static void UpdateStudentInfo(EntEducationalInfo ee)
        {
            try
            {
                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateFSC", con);
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


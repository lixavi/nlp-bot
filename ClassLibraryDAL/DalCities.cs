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
    public class DalCities
    {
        public static List<EntCities> GetCities()
        {
            List<EntCities> CitiesList = new List<EntCities>();
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    EntCities ee = new EntCities();
                    ee.CityId = sdr["CityId"].ToString();
                    ee.CityName = sdr["CityName"].ToString();
                    ee.CityCode = sdr["CityCode"].ToString();
                    CitiesList.Add(ee);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }
            return CitiesList;
        }


        public static EntCities GetCityById(string? CityId)
        {
            EntCities ee = new EntCities();
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetCityById", con);
                cmd.Parameters.AddWithValue("@CityId", CityId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    ee.CityId = sdr["CityId"].ToString();
                    ee.CityName = sdr["CityName"].ToString();
                    ee.CityCode = sdr["CityCode"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }
            return ee;
        }

        public static void SaveCities(EntCities ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveCities", con);
                cmd.Parameters.AddWithValue("@CityName", ee.CityName);
                cmd.Parameters.AddWithValue("@CityCode", ee.CityCode);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }

        }


        public static void DeleteCities(string CityId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteCities", con);
                cmd.Parameters.AddWithValue("@CityId", int.Parse(CityId));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);
            }
        }


        public static void UpdateCities(EntCities? ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateCities", con);
                cmd.Parameters.AddWithValue("@CityId", int.Parse(ee.CityId));
                cmd.Parameters.AddWithValue("@CityName", ee.CityName);
                cmd.Parameters.AddWithValue("@CityCode", ee.CityCode);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)                 
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();

                GetError(Excep);

            }

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

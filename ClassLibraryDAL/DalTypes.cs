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
    public class DalTypes
    {
        public static string? Excep { get; set; }

        public static List<EntTypes> GetTypeOfs()
        {
            List<EntTypes> TypesList = new List<EntTypes>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetTypeOfs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntTypes ee = new EntTypes();
                    ee.TypeOfId = sdr["TypeOfId"].ToString();
                    ee.Type = sdr["Type"].ToString();
                    TypesList.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }


            return TypesList;
        }

        //GetTypeById
        public static EntTypes GetTypeById(string? TypeOfId)
        {
            EntTypes ee = new EntTypes();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_GetTypeById", con);
                cmd.Parameters.AddWithValue("@TypeOfId", TypeOfId);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ee.TypeOfId = sdr["TypeOfId"].ToString();
                    ee.Type = sdr["Type"].ToString();
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
        public static void SaveTypeOfs(EntTypes? ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveTypeOfs", con);
                cmd.Parameters.AddWithValue("@Type", ee.Type);
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


        public static void DeleteTypeOfs(string TypeOfId)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteTypeOfs", con);
                cmd.Parameters.AddWithValue("@TypeOfId", int.Parse(TypeOfId));
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


        public static void UpdateTypesOfs(EntTypes? ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateTypeOfs", con);
                cmd.Parameters.AddWithValue("@TypeOfId", int.Parse(ee.TypeOfId));
                cmd.Parameters.AddWithValue("@Type", ee.Type);
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

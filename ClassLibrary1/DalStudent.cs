using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryModel;

namespace ClassLibraryDal
{
    public class DalStudent
    {
        public static void SaveStudentInformation(ModelStudent ms) 
        {
            SqlConnection con =DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd =  new SqlCommand("SPr_SaveStudent",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", ms.FirstName);
            cmd.Parameters.AddWithValue("@EmailAddress", ms.EmailAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateStudentInformation(ModelStudent ms)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPr_UpdateStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StuId", ms.StuId);
            cmd.Parameters.AddWithValue("@FirstName", ms.FirstName);
            cmd.Parameters.AddWithValue("@EmailAddress", ms.EmailAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteStudentInformation(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPr_DeleteStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StuId", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static ModelStudent GetStudentInfoById(int id)
        {
            ModelStudent student = new ModelStudent();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetStudentById", con);
            cmd.Parameters.AddWithValue("@StuId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              
                student.StuId = Convert.ToInt32(reader["StuId"]);
                student.FirstName = reader["FirstName"].ToString();
                student.EmailAddress = reader["EmailAddress"].ToString();
               
            }
            con.Close();
            return student;

        }
        public static List<ModelStudent> GetStudentsInformation()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPr_GetStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelStudent> listStudents = new List<ModelStudent>();
            while (reader.Read())
            {
                ModelStudent student = new ModelStudent();
                student.StuId =Convert.ToInt32(reader["StuId"]);
                student.FirstName = reader["FirstName"].ToString();
                student.EmailAddress = reader["EmailAddress"].ToString();
                listStudents.Add(student);
            }
            con.Close();
            return listStudents;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace school_system
{
    class Clsdata
    {

        public DataTable dt = new DataTable();

        public void selectstudents(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = s;

            clssetting.cn.Open();
            dt.Load(cmd.ExecuteReader());
            clssetting.cn.Close();
        }





        public void insertstudents(string name, string ph,int gid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertstudents";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@ph", SqlDbType.VarChar, 11).Value = ph;
            cmd.Parameters.Add("@gid", SqlDbType.Int).Value = gid;



            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }


        public void deletestudents(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deletestudents";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }
        public void updatestudents(string name, string ph, int id,int gid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updatestudents";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@ph", SqlDbType.VarChar, 11).Value = ph;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@gid", SqlDbType.Int).Value = gid;


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }



        public void insertgrade(string grade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertgrade";
            cmd.Parameters.Add("@grade", SqlDbType.VarChar, 50).Value = grade;
            


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }



        public void deletegrade(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deletegrade";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }


        public void updategrade( string grade, int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updategrade";
            cmd.Parameters.Add("@grade", SqlDbType.VarChar, 50).Value = grade;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }



        /////////////// TEACHERRRRR 

       public void insertteacher(string name, string ph)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertteacher";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@ph", SqlDbType.VarChar, 50).Value = ph;
     
            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }


        public void deleteteacher(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "deleteteacher";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }


        public void updateteacher(string name, string ph, int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = clssetting.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateteacher";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@ph", SqlDbType.VarChar, 11).Value = ph;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
         


            clssetting.cn.Open();
            cmd.ExecuteNonQuery();
            clssetting.cn.Close();
        }


        

    }


}
























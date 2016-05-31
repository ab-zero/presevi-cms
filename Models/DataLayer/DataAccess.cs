using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace presevi_cms.Models.DataLayer
{
    public class DataAccess
    {
        public string ConnectionString { get; set; }

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public DataAccess()
        {
            this.ConnectionString = this.GetConnString();
        }

        private string GetConnString()
        {
            //return @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\content.mdf;";
            return System.Configuration.ConfigurationManager.ConnectionStrings["ContentDataConnection"].ToString(); ;
        }

        public DataSet GetData(string contentType)
        {
            string query = "select ID,ContentType, TargetUrl, ImageUrl, AltText, Header, Content, Sequence from tblImageContent where ContentType = '" + contentType + "'";
            return ExecuteDataSet(query, "tblImageContent");
        }

        public bool Authenticate(string userName, string password)
        {

            string query = "SELECT Count(*) FROM tblUserProfile where UserName=@user and password=@password;";
            
            object value = null;
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@user", userName);
                cmd.Parameters.AddWithValue("@password", password);
                value = cmd.ExecuteScalar();
                con.Close();
            }
            int count = Helper.ConvertToInt(value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetMaxId(string tableName, string colName)
        {
            string query = "SELECT MAX(" + colName + ") FROM [" + tableName + "];";
            return Helper.ConvertToInt(ExecuteScalar(query));
        }

        private DataSet ExecuteDataSet(string query, string tableName)
        {
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();

                ds = new DataSet();

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(ds);
                }

                con.Close();
            }

            return ds;
        }

        private object ExecuteScalar(string query)
        {
            object value = null;
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                value = cmd.ExecuteScalar();
                con.Close();
            }

            return value;
        }

        //private void ExecuteNonQuery(string query)
        //{
        //    using (SQLiteConnection con = new SQLiteConnection(this.ConnectionString))
        //    {
        //        con.Open();
        //        SQLiteCommand cmd = con.CreateCommand();
        //        cmd.CommandText = query;
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
    }
}
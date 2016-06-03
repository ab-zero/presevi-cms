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

        public DataSet GetBannerClientileData(string contentType)
        {
            string query = "select ID,ContentType, TargetUrl, ImageUrl, ImageAltText, ImageHeader, Description, tags, Sequence from tblBannerCLientile where ContentType = '" + contentType + "'";
            return ExecuteDataSet(query, "tblBannerCLientile");
        }

        public DataSet GetProductCategoryCData(string contentType)
        {
            string query = "select Id, ContentType, ImageUrl, ImageAltText, ProductCategory, ImageHeader, Description, PageContent, Tags, Sequence from tblProductCategory";
            return ExecuteDataSet(query, "tblProductCategory");
        }

        public DataSet GetProductDetailData(string contentType)
        {
            string query = "select Id, ContentType, ImageUrl, ImageAltText, ProductCategory, Description, PageContent, Tags, Sequence from tblProductDetail";
            return ExecuteDataSet(query, "tblProductDetail");
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


        public void CreateBannerClientile(BannerClientileModel imageContent)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblBannerClientile", "Id") + 1;
            maxSequence = GetMaxSequence("tblBannerClientile", "Sequence", imageContent.ContentType) + 1;
            query = "INSERT INTO [tblBannerClientile]([Id],[ContentType], [TargetUrl], [ImageUrl], [ImageAltText], [ImageHeader], [Description], [Tags], [Sequence])VALUES(" +
                maxId + ",'" + imageContent.ContentType + "','" + imageContent.TargetUrl + "','" + imageContent.ImageUrl + "','" +
                imageContent.ImageAltText + "','" + imageContent.ImageHeader + "','" + imageContent.Description + "','" + imageContent.Tags + "'," + maxSequence + ");";

            ExecuteNonQuery(query);
        }

        public void CreateProductCategory(ProductCategoryModel productCategory)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblProductCategory", "Id") + 1;
            maxSequence = GetMaxSequence("tblProductCategory", "Sequence", productCategory.ContentType) + 1;
            query = "INSERT INTO [tblProductCategory]([Id],[ContentType], [ImageUrl], [ImageAltText],[ProductCategory], [Description],[PageContent], [Tags], [Sequence])VALUES(" +
                maxId + ",'" + productCategory.ContentType +  "','" + productCategory.ImageUrl + "','" +
                productCategory.ImageAltText + "','" + productCategory.ProductCategory + "','" + productCategory.Description +
                "','" + productCategory.PageContent + "','" + productCategory.Tags + "'," + maxSequence + ");";

            ExecuteNonQuery(query);
        }

        public void CreateProductDetail(ProductDetailModel productDetail)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblProductDetail", "Id") + 1;
            maxSequence = GetMaxSequence("tblProductDetail", "Sequence", productDetail.ContentType) + 1;
            query = "INSERT INTO [tblProductDetail]([Id],[ContentType], [ImageUrl], [ImageAltText], [ProductName], [ProductCategory]," +
                "[ImageHeader], [Description], [PageContent], [Tags], [Sequence])VALUES(" +
                maxId + ",'" + productDetail.ContentType + "','" +  productDetail.ImageUrl + "','" +
                productDetail.ImageAltText + "','" + productDetail.ProductName + "','" + productDetail.ProductCategory + "','" +
                productDetail.Description + "','" + productDetail.PageContent + "','" + productDetail.Tags + "'," + maxSequence + ");";

            ExecuteNonQuery(query);
        }

        public void EditImageContent(BannerClientileModel imageContent)
        {
            string query = string.Empty;
            query = String.Format("Update [tblImageContent] set [ContentType] = {0}, [TargetUrl] ={1}, [ImageUrl]={2}, [AltText]={3}, [Header]={4}, [Content]={5}, [Sequence]={6} where Id = {7}",
                imageContent.ContentType, imageContent.TargetUrl, imageContent.ImageUrl, imageContent.ImageAltText, imageContent.ImageHeader, imageContent.Description, imageContent.Sequence, imageContent.Id);

            ExecuteNonQuery(query);
        }

        public void DeleteImageContent(BannerClientileModel imageContent)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblImageContent", "Id") + 1;
            maxSequence = GetMaxSequence("tblImageContent", "Sequence", imageContent.ContentType) + 1;
            query = "Delete [tblImageContent] where Id = " + imageContent.Id;

            ExecuteNonQuery(query);
        }
        private int GetMaxId(string tableName, string colName)
        {
            string query = "SELECT MAX(" + colName + ") FROM [" + tableName + "];";
            return Helper.ConvertToInt(ExecuteScalar(query));
        }

        private int GetMaxSequence(string tableName, string colName, string contentType)
        {
            string query = "SELECT MAX(" + colName + ") FROM [" + tableName + "] where ContentType='" + contentType + "';";
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

        private void ExecuteNonQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
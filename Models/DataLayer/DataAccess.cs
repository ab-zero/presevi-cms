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

        #region CRUD
        public void CreateBannerClientile(BannerClientileModel imageContent)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblBannerClientile", "Id") + 1;
            maxSequence = GetMaxSequence("tblBannerClientile", "Sequence", imageContent.ContentType) + 1;
            query = "INSERT INTO [tblBannerClientile]([Id],[ContentType], [TargetUrl], [ImageUrl], [ImageAltText], [ImageHeader], [Description], [Tags], [Sequence])" +
                "VALUES(@maxId ,@ContentType, @TargetUrl ,@ImageUrl, @ImageAltText, @ImageHeader, @Description, @Tags, @maxSequence)";

            //maxId + ",'" + imageContent.ContentType + "','" + imageContent.TargetUrl + "','" + imageContent.ImageUrl + "','" +
            //imageContent.ImageAltText + "','" + imageContent.ImageHeader + "','" + imageContent.Description + "','" + imageContent.Tags + "'," + maxSequence + ");";
            List<SqlParameter> spList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            spList.Add(new SqlParameter("@maxId", maxId));
            spList.Add(new SqlParameter("@ContentType", imageContent.ContentType));
            spList.Add(new SqlParameter("@TargetUrl", imageContent.TargetUrl));
            spList.Add(new SqlParameter("@ImageUrl", imageContent.ImageUrl));
            spList.Add(new SqlParameter("@ImageAltText", imageContent.ImageAltText));
            spList.Add(new SqlParameter("@ImageHeader", imageContent.ImageHeader));
            spList.Add(new SqlParameter("@Description", imageContent.Description));
            spList.Add(new SqlParameter("@Tags", imageContent.Tags));
            spList.Add(new SqlParameter("@maxSequence", maxSequence));
            ExecuteNonQueryWithParms(query, spList);
        }

        public void CreateProductCategory(ProductCategoryModel productCategory)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblProductCategory", "Id") + 1;
            maxSequence = GetMaxSequence("tblProductCategory", "Sequence", productCategory.ContentType) + 1;
            query = "INSERT INTO [tblProductCategory]([Id],[ContentType], [ImageUrl], [ImageAltText],[ProductCategory], [Description],[PageContent], [Tags], " +
                "[Sequence], [CategorySlug])VALUES(@maxId ,@ContentType ,@ImageUrl, @ImageAltText ,@ProductCategory, @Description ,@PageContent ,@Tags, @maxSequence, @CategorySlug)";
            //maxId + ",'" + productCategory.ContentType + "','" + productCategory.ImageUrl + "','" +
            //productCategory.ImageAltText + "','" + productCategory.ProductCategory + "','" + productCategory.Description +
            //"','" + productCategory.PageContent + "','" + productCategory.Tags + "'," + maxSequence + ");";
            List<SqlParameter> spList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            spList.Add(new SqlParameter("@maxId", maxId));
            spList.Add(new SqlParameter("@ContentType", productCategory.ContentType));
            spList.Add(new SqlParameter("@ImageUrl", productCategory.ImageUrl));
            spList.Add(new SqlParameter("@ImageAltText", productCategory.ImageAltText));
            spList.Add(new SqlParameter("@ProductCategory", productCategory.ProductCategory));
            spList.Add(new SqlParameter("@Description", productCategory.Description));
            spList.Add(new SqlParameter("@PageContent", productCategory.PageContent));
            spList.Add(new SqlParameter("@Tags", productCategory.Tags));
            spList.Add(new SqlParameter("@maxSequence", maxSequence));
            spList.Add(new SqlParameter("@CategorySlug", productCategory.CategorySlug));
            ExecuteNonQueryWithParms(query, spList);
        }

        public void CreateProductDetail(ProductDetailModel productDetail)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblProductDetail", "Id") + 1;
            maxSequence = GetMaxSequence("tblProductDetail", "Sequence", productDetail.ContentType) + 1;
            query = "INSERT INTO [tblProductDetail]([Id],[ContentType], [ImageUrl], [ImageAltText], [ProductName], [ProductCategory]," +
                "[Description], [PageContent], [Tags], [Sequence], [ProductSlug])VALUES(@maxId ,@ContentType ,@ImageUrl, " +
                "@ImageAltText ,@ProductName ,@ProductCategory, @Description ,@PageContent ,@Tags, @maxSequence, @ProductSlug)";
            List<SqlParameter> spList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            spList.Add(new SqlParameter("@maxId", maxId));
            spList.Add(new SqlParameter("@ContentType", productDetail.ContentType));
            spList.Add(new SqlParameter("@ImageUrl", productDetail.ImageUrl));
            spList.Add(new SqlParameter("@ImageAltText", productDetail.ImageAltText));
            spList.Add(new SqlParameter("@ProductName", productDetail.ProductName));
            spList.Add(new SqlParameter("@ProductCategory", productDetail.ProductCategory));
            spList.Add(new SqlParameter("@Description", productDetail.Description));
            spList.Add(new SqlParameter("@PageContent", productDetail.PageContent));
            spList.Add(new SqlParameter("@Tags", productDetail.Tags));
            spList.Add(new SqlParameter("@maxSequence", maxSequence));
            spList.Add(new SqlParameter("@ProductSlug", productDetail.ProductSlug));
            //maxId + ",'" + productDetail.ContentType + "','" + productDetail.ImageUrl + "','" +
            //    productDetail.ImageAltText + "','" + productDetail.ProductName + "','" + productDetail.ProductCategory + "','" +
            //    productDetail.Description + "','" + productDetail.PageContent + "','" + productDetail.Tags + "'," + maxSequence + ");";

            ExecuteNonQueryWithParms(query, spList);
        }

        public DataSet GetBannerClientileData(string contentType)
        {
            string query = "select ID,ContentType, TargetUrl, ImageUrl, ImageAltText, ImageHeader, Description, tags, Sequence from tblBannerCLientile where ContentType = '" + contentType + "'";
            return ExecuteDataSet(query, "tblBannerCLientile");
        }

        public DataSet GetProductCategoryDataAll(string contentType)
        {
            string query = "select Id, ContentType, ImageUrl, ImageAltText, ProductCategory, ImageHeader, Description, PageContent, Tags, Sequence, CategorySlug from tblProductCategory";
            return ExecuteDataSet(query, "tblProductCategory");
        }

        public DataSet GetProductCategoryDataFiltered(string contentType, string categorySlug)
        {
            //Gets only the first row of product category 
            string query = "select top 1 Id, ContentType, ImageUrl, ImageAltText, ProductCategory, ImageHeader, Description, PageContent, Tags, Sequence, CategorySlug from tblProductCategory where CategorySlug = '" + categorySlug + "'";
            return ExecuteDataSet(query, "tblProductCategory");
        }

        public DataSet GetProductDetailDataAll(string contentType)
        {
            string query = "select Id, ProductName, ContentType, ImageUrl, ImageAltText, ProductCategory, Description, PageContent, Tags, Sequence,ProductSlug from tblProductDetail";
            return ExecuteDataSet(query, "tblProductDetail");
        }

        public DataSet GetProductDetailDataFiltered(string contentType, string productSlug)
        {
            string query = "select top 1 Id, ProductName, ContentType, ImageUrl, ImageAltText, ProductCategory, Description, PageContent, Tags, Sequence, ProductSlug from tblProductDetail " +
                "where ProductSlug='" + productSlug + "'";
            return ExecuteDataSet(query, "tblProductDetail");
        }

        public DataSet GetProductDetailCategory(string contentType, string productCategory)
        {
            string query = "select top 1 pd.Id, pd.ProductName, pd.ContentType, pd.ImageUrl, pd.ImageAltText, pd.ProductCategory, pd.Description, pd.PageContent, pd.Tags, " +
                "pd.Sequence, pd.ProductSlug from tblProductDetail pd join tblProductCategory pc on pc.ProductCategory = pd.ProductCategory " +
                "where pc.CategorySlug ='" + productCategory + "'";
            return ExecuteDataSet(query, "tblProductDetail");
        }

        #region Update

        public void UpdateBannerClientile(BannerClientileModel imageContent)
        {
            string query = string.Empty;

            query = "UPDATE [tblBannerClientile] set [TargetUrl]=@TargetUrl, [ImageUrl] = @ImageUrl, [ImageAltText] = @ImageAltText, " +
                "[ImageHeader] = @ImageHeader, [Description] = @Description, [Tags] = @Tags " +
                "WHERE ID = @ContentId";

            List<SqlParameter> spList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            spList.Add(new SqlParameter("@TargetUrl", imageContent.TargetUrl));
            spList.Add(new SqlParameter("@ImageUrl", imageContent.ImageUrl));
            spList.Add(new SqlParameter("@ImageAltText", imageContent.ImageAltText));
            spList.Add(new SqlParameter("@ImageHeader", imageContent.ImageHeader));
            spList.Add(new SqlParameter("@Description", imageContent.Description));
            spList.Add(new SqlParameter("@Tags", imageContent.Tags));
            spList.Add(new SqlParameter("@ContentId", imageContent.Id));
            ExecuteNonQueryWithParms(query, spList);
        }

        public void UpdateProductCategory(ProductCategoryModel productCategory)
        {
            string query = string.Empty;
            query = "UPDATE [tblProductCategory] set [ImageUrl]= @ImageUrl, [ImageAltText]= @ImageAltText,[ProductCategory] =@ProductCategory, " +
                "[Description]= @Description,[PageContent]=@PageContent, [Tags]=@Tags, " +
                "[CategorySlug] = @CategorySlug where ID = @ContentId";
            //maxId + ",'" + productCategory.ContentType + "','" + productCategory.ImageUrl + "','" +
            //productCategory.ImageAltText + "','" + productCategory.ProductCategory + "','" + productCategory.Description +
            //"','" + productCategory.PageContent + "','" + productCategory.Tags + "'," + maxSequence + ");";
            List<SqlParameter> spList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            spList.Add(new SqlParameter("@ImageUrl", productCategory.ImageUrl));
            spList.Add(new SqlParameter("@ImageAltText", productCategory.ImageAltText));
            spList.Add(new SqlParameter("@ProductCategory", productCategory.ProductCategory));
            spList.Add(new SqlParameter("@Description", productCategory.Description));
            spList.Add(new SqlParameter("@PageContent", productCategory.PageContent));
            spList.Add(new SqlParameter("@Tags", productCategory.Tags));
            spList.Add(new SqlParameter("@CategorySlug", productCategory.CategorySlug));
            spList.Add(new SqlParameter("@ContentId", productCategory.Id));
            ExecuteNonQueryWithParms(query, spList);
        }

        public void UpdateProductDetail(ProductDetailModel productDetail)
        {
            string query = string.Empty;
            query = "UPDATE [tblProductDetail] set [ImageUrl]= @ImageUrl, [ImageAltText]= @ImageAltText,[ProductCategory] =@ProductCategory, " +
               "[ProductName]= @ProductName, [Description]= @Description,[PageContent]=@PageContent, [Tags]=@Tags, " +
               "[CategorySlug] = @CategorySlug where ID = @ContentId";
            List<SqlParameter> spList = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            spList.Add(new SqlParameter("@ImageUrl", productDetail.ImageUrl));
            spList.Add(new SqlParameter("@ImageAltText", productDetail.ImageAltText));
            spList.Add(new SqlParameter("@ProductName", productDetail.ProductName));
            spList.Add(new SqlParameter("@ProductCategory", productDetail.ProductCategory));
            spList.Add(new SqlParameter("@Description", productDetail.Description));
            spList.Add(new SqlParameter("@PageContent", productDetail.PageContent));
            spList.Add(new SqlParameter("@Tags", productDetail.Tags));
            spList.Add(new SqlParameter("@ProductSlug", productDetail.ProductSlug));
            spList.Add(new SqlParameter("@ContentId", productDetail.Id));
            //maxId + ",'" + productDetail.ContentType + "','" + productDetail.ImageUrl + "','" +
            //    productDetail.ImageAltText + "','" + productDetail.ProductName + "','" + productDetail.ProductCategory + "','" +
            //    productDetail.Description + "','" + productDetail.PageContent + "','" + productDetail.Tags + "'," + maxSequence + ");";

            ExecuteNonQueryWithParms(query, spList);
        }

        #endregion Update

        public void DeleteImageContent(BannerClientileModel imageContent)
        {
            int maxId, maxSequence;
            string query = string.Empty;

            maxId = GetMaxId("tblImageContent", "Id") + 1;
            maxSequence = GetMaxSequence("tblImageContent", "Sequence", imageContent.ContentType) + 1;
            query = "Delete [tblImageContent] where Id = " + imageContent.Id;

            ExecuteNonQuery(query);
        }

        #endregion CRUD

        #region Private Helpers

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

        private void ExecuteNonQueryWithParms(string query, List<SqlParameter> sParmList)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.Parameters.AddRange(sParmList.ToArray());
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        #endregion Private Helpers
    }
}
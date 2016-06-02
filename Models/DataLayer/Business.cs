using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace presevi_cms.Models.DataLayer
{
    public class Business
    {
        private DataAccess dataAccess = null;
        public Business()
        {
            dataAccess = new DataAccess();
        }

        public List<BannerClientileModel> GetContent(string contentType){
            List<BannerClientileModel> lstContent = new List<BannerClientileModel>();
            using (DataSet ds = dataAccess.GetData(contentType))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        BannerClientileModel content = new BannerClientileModel()
                        {
                            
                            Id = Helper.ConvertToInt(dataRow["Id"]),
                            ContentType = Helper.GetDbValue(dataRow["ContentType"]),
                            TargetUrl = Helper.GetDbValue(dataRow["TargetUrl"]),
                            ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]),
                            ImageAltText = Helper.GetDbValue(dataRow["AltText"]),
                            ImageHeader = Helper.GetDbValue(dataRow["Header"]),
                            Description = Helper.GetDbValue(dataRow["content"]),
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"])
                        };

                        lstContent.Add(content);
                    }
                }
            }

            return lstContent;

        }

        public string CreateBannerClientileContent(BannerClientileModel imageContent)
        {
            try
            {
                dataAccess.CreateBannerClientile(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateProductCategory(ProductCategoryModel imageContent)
        {
            try
            {
                dataAccess.CreateProductCategory(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateProductDetail(ProductDetailModel imageContent)
        {
            try
            {
                dataAccess.CreateProductDetail(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string EditImageContent(BannerClientileModel imageContent)
        {
            try
            {
                dataAccess.EditImageContent(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteImageContent(BannerClientileModel imageContent)
        {
            try
            {
                dataAccess.DeleteImageContent(imageContent);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AuthenticateUser(string userName, string password)
        {
            return dataAccess.Authenticate(userName, password);
        }
    }
}
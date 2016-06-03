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

        public List<BannerClientileModel> GetBannerClientileData(string contentType)
        {
            List<BannerClientileModel> lstContent = new List<BannerClientileModel>();
            using (DataSet ds = dataAccess.GetBannerClientileData(contentType))
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
                            ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]),
                            ImageHeader = Helper.GetDbValue(dataRow["ImageHeader"]),
                            Description = Helper.GetDbValue(dataRow["Description"]),
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"])
                        };

                        lstContent.Add(content);
                    }
                }
            }

            return lstContent;

        }

        public List<ProductCategoryModel> GetProdcutCategoryData(string contentType)
        {
            List<ProductCategoryModel> lstContent = new List<ProductCategoryModel>();
            using (DataSet ds = dataAccess.GetProductCategoryCData(contentType))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        ProductCategoryModel content = new ProductCategoryModel()
                        {
                            Id = Helper.ConvertToInt(dataRow["Id"]),
                            ContentType = Helper.GetDbValue(dataRow["ContentType"]),
                            ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]),
                            ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]),
                            ProductCategory = Helper.GetDbValue(dataRow["ProductCategory"]),
                            Description = Helper.GetDbValue(dataRow["Description"]),
                            PageContent = Helper.GetDbValue(dataRow["PageContent"]),
                            Tags = Helper.GetDbValue(dataRow["Tags"]),
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"])
                        };
                        lstContent.Add(content);
                    }
                }
            }
            return lstContent;
        }


        public List<ProductDetailModel> GetProdcutDetailData(string contentType)
        {
            List<ProductDetailModel> lstContent = new List<ProductDetailModel>();
            //using (DataSet ds = dataAccess.GetBannerClientileData(contentType))
            //{
            //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        foreach (DataRow dataRow in ds.Tables[0].Rows)
            //        {
            //            BannerClientileModel content = new BannerClientileModel()
            //            {

            //                Id = Helper.ConvertToInt(dataRow["Id"]),
            //                ContentType = Helper.GetDbValue(dataRow["ContentType"]),
            //                TargetUrl = Helper.GetDbValue(dataRow["TargetUrl"]),
            //                ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]),
            //                ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]),
            //                ImageHeader = Helper.GetDbValue(dataRow["ImageHeader"]),
            //                Description = Helper.GetDbValue(dataRow["Description"]),
            //                Tags = Helper.GetDbValue(dataRow["Tags"]),
            //                Sequence = Helper.ConvertToInt(dataRow["Sequence"])
            //            };

            //            lstContent.Add(content);
            //        }
            //    }
            //}
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
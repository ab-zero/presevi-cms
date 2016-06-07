using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace presevi_cms.Models.DataLayer
{
    public class Business
    {
        #region Declaration
        private DataAccess dataAccess = null;
        public Business()
        {
            dataAccess = new DataAccess();
        }
        #endregion Declaration

        #region Create
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

        #endregion Create

        #region Read
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

        public List<ProductCategoryModel> GetProdcutCategoryDataAll(string contentType)
        {
            List<ProductCategoryModel> lstContent = new List<ProductCategoryModel>();
            using (DataSet ds = dataAccess.GetProductCategoryDataAll(contentType))
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
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"]),
                            CategorySlug = Helper.GetDbValue(dataRow["CategorySlug"])
                        };
                        lstContent.Add(content);
                    }
                }
            }
            return lstContent;
        }

        public ProductCategoryModel GetProdcutCategoryDataFiltered(string contentType, string categorySlug)
        {
            List<ProductCategoryModel> lstContent = new List<ProductCategoryModel>();
            ProductCategoryModel content = new ProductCategoryModel();
            using (DataSet ds = dataAccess.GetProductCategoryDataFiltered(contentType, categorySlug))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dataRow = ds.Tables[0].Rows[0];

                    content.Id = Helper.ConvertToInt(dataRow["Id"]);
                    content.ContentType = Helper.GetDbValue(dataRow["ContentType"]);
                    content.ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]);
                    content.ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]);
                    content.ProductCategory = Helper.GetDbValue(dataRow["ProductCategory"]);
                    content.Description = Helper.GetDbValue(dataRow["Description"]);
                    content.PageContent = Helper.GetDbValue(dataRow["PageContent"]);
                    content.Tags = Helper.GetDbValue(dataRow["Tags"]);
                    content.Sequence = Helper.ConvertToInt(dataRow["Sequence"]);
                    content.CategorySlug = Helper.GetDbValue(dataRow["CategorySlug"]);
                }
            }
            return content;
        }

        public List<ProductDetailModel> GetProductDetailDataAll(string contentType)
        {
            List<ProductDetailModel> lstContent = new List<ProductDetailModel>();
            using (DataSet ds = dataAccess.GetProductDetailDataAll(contentType))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        ProductDetailModel content = new ProductDetailModel()
                        {

                            Id = Helper.ConvertToInt(dataRow["Id"]),
                            ContentType = Helper.GetDbValue(dataRow["ContentType"]),
                            ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]),
                            ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]),
                            ProductName = Helper.GetDbValue(dataRow["ProductName"]),
                            ProductCategory = Helper.GetDbValue(dataRow["ProductCategory"]),
                            Description = Helper.GetDbValue(dataRow["Description"]),
                            PageContent = Helper.GetDbValue(dataRow["PageContent"]),
                            Tags = Helper.GetDbValue(dataRow["Tags"]),
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"]),
                            ProductSlug = Helper.GetDbValue(dataRow["ProductSlug"])
                        };

                        lstContent.Add(content);
                    }
                }
            }
            return lstContent;
        }

        public ProductDetailModel GetProductDetailDataFiltered(string contentType, string productSlug)
        {
            ProductDetailModel productDetail = new ProductDetailModel();
            using (DataSet ds = dataAccess.GetProductDetailDataFiltered(contentType, productSlug))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dataRow = ds.Tables[0].Rows[0];
                    productDetail.Id = Helper.ConvertToInt(dataRow["Id"]);
                    productDetail.ContentType = Helper.GetDbValue(dataRow["ContentType"]);
                    productDetail.ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]);
                    productDetail.ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]);
                    productDetail.ProductName = Helper.GetDbValue(dataRow["ProductName"]);
                    productDetail.ProductCategory = Helper.GetDbValue(dataRow["ProductCategory"]);
                    productDetail.Description = Helper.GetDbValue(dataRow["Description"]);
                    productDetail.PageContent = Helper.GetDbValue(dataRow["PageContent"]);
                    productDetail.Tags = Helper.GetDbValue(dataRow["Tags"]);
                    productDetail.Sequence = Helper.ConvertToInt(dataRow["Sequence"]);
                    productDetail.ProductSlug = Helper.GetDbValue(dataRow["ProductSlug"]);

                }
            }
            return productDetail;
        }

        public List<ProductDetailModel> GetProductDetailDataCategory(string contentType, string productCategory)
        {
            List<ProductDetailModel> lstContent = new List<ProductDetailModel>();
            using (DataSet ds = dataAccess.GetProductDetailCategory(contentType, productCategory))
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dataRow in ds.Tables[0].Rows)
                    {
                        ProductDetailModel content = new ProductDetailModel()
                        {

                            Id = Helper.ConvertToInt(dataRow["Id"]),
                            ContentType = Helper.GetDbValue(dataRow["ContentType"]),
                            ImageUrl = Helper.GetDbValue(dataRow["ImageUrl"]),
                            ImageAltText = Helper.GetDbValue(dataRow["ImageAltText"]),
                            ProductName = Helper.GetDbValue(dataRow["ProductName"]),
                            ProductCategory = Helper.GetDbValue(dataRow["ProductCategory"]),
                            Description = Helper.GetDbValue(dataRow["Description"]),
                            PageContent = Helper.GetDbValue(dataRow["PageContent"]),
                            Tags = Helper.GetDbValue(dataRow["Tags"]),
                            Sequence = Helper.ConvertToInt(dataRow["Sequence"]),
                            ProductSlug = Helper.GetDbValue(dataRow["ProductSlug"])
                        };

                        lstContent.Add(content);
                    }
                }
            }
            return lstContent;
        }
        #endregion Read

        #region Update
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

        #endregion Update

        #region Delete
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

        #endregion Delete

        #region Authenticate
        public bool AuthenticateUser(string userName, string password)
        {
            return dataAccess.Authenticate(userName, password);
        }
        #endregion Authenticate
    }
}
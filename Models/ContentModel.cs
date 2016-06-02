using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace presevi_cms.Models
{

    public class PreseviDataContext : DbContext
    {
        public PreseviDataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<BannerClientileModel> UserProfiles { get; set; }
    }

    public class BannerClientileModel
    {

        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required(ErrorMessage="Target url is Missing")]
        public string TargetUrl { get; set; }

        [Required(ErrorMessage="Image url is Missing")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage="ImageAltText is Missing")]
        public string ImageAltText { get; set; }

        [Required(ErrorMessage="Image Header is Missing")]
        public string ImageHeader { get; set; }

        [Required(ErrorMessage="Description is Missing")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Description is Missing")]
        public string Tags { get; set; }

        public int Sequence { get; set; }

    }

    public class ProductCategoryModel
    {

        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required(ErrorMessage = "Image url is Missing")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "ImageAltText is Missing")]
        public string ImageAltText { get; set; }

        [Required(ErrorMessage = "Image Header is Missing")]
        public string ProductCategory { get; set; }

        [Required(ErrorMessage = "Description is Missing")]
        public string Description { get; set; }

        [Required(ErrorMessage = "PageContent is Missing")]
        public string PageContent { get; set; }

        [Required(ErrorMessage = "Tags Missing")]
        public string Tags { get; set; }

        public int Sequence { get; set; }

    }

    public class ProductDetailModel
    {

        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required(ErrorMessage = "Image url is Missing")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "ImageAltText is Missing")]
        public string ImageAltText { get; set; }

        [Required(ErrorMessage = "ProductName is Missing")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Category is Missing")]
        public string ProductCategory { get; set; }

        [Required(ErrorMessage = "Description is Missing")]
        public string Description { get; set; }

        [Required(ErrorMessage = "PageContent is Missing")]
        public string PageContent { get; set; }

        [Required(ErrorMessage = "Tags Missing")]
        public string Tags { get; set; }

        public int Sequence { get; set; }

    }
}
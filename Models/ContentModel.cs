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

        public DbSet<PreseviDataModel> UserProfiles { get; set; }
    }

    public class PreseviDataModel
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

        public int Sequence { get; set; }

    }
}
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
        [Required]
        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public string TargetUrl { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string ImageAltText { get; set; }

        [Required]
        public string ImageHeader { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Sequence { get; set; }

    }
}
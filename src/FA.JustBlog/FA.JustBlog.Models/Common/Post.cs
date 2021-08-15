﻿using FA.JustBlog.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models.Common
{
    [Table("Posts", Schema = "common")]
    public class Post : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must less than {1} characters")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 4)]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 4)]
        [Display(Name = "Image Slider")]
        public string ImageSlider { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [Display(Name = "Post Content")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        [Display(Name = "Url Slug")]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PublishedDate { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [Display(Name = "View Count")]
        public int ViewCount { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [Display(Name = "Rate Count")]
        public int RateCount { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [Display(Name = "Total Rate")]
        public int TotalRate { get; set; }

        public decimal Rate => RateCount == 0 ? 0 : TotalRate / RateCount;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

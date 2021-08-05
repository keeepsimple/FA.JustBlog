using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FA.JustBlog.MVC.Areas.Admin.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must less than {1} characters")]
        public string ShortDescription { get; set; }

        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 4)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int ViewCount { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int RateCount { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public int TotalRate { get; set; }

        public IEnumerable<Guid> SelectedTagIds { get; set; }

        public IEnumerable<SelectListItem> Tags { get; set; }
    }
}
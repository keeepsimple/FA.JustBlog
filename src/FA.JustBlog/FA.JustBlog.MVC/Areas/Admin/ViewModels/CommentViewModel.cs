using System;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.MVC.Areas.Admin.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string CommentHeader { get; set; }

        [MaxLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string CommentText { get; set; }

        public string CommentTime { get; set; }

        public Guid PostId { get; set; }
    }
}
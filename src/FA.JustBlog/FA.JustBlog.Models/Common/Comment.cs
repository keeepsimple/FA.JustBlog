using FA.JustBlog.Models.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models.Common
{
    [Table("Comments", Schema = "common")]
    public class Comment : BaseEntity
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        [Display(Name="Comment Header")]
        public string CommentHeader { get; set; }

        [MaxLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; }

        [Display(Name = "Comment Time")]
        public DateTime CommentTime { get; set; }

        [ForeignKey("Post")]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
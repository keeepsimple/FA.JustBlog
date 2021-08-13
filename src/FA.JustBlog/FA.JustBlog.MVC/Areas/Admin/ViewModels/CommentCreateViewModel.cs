using System;

namespace FA.JustBlog.MVC.Areas.Admin.ViewModels
{
    public class CommentCreateViewModel
    {
        public Guid PostId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }
    }
}
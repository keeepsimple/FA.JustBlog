using System;

namespace FA.JustBlog.Api.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        public DateTime InsertedAt { get; set; }
    }
}
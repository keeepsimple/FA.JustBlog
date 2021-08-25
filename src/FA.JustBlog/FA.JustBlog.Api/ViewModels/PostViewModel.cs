using System;
using System.Collections.Generic;

namespace FA.JustBlog.Api.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public string ImageSlider { get; set; }

        public string PostContent { get; set; }

        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        public Guid CategoryId { get; set; }

        public List<Guid> TagIds { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime InsertedAt { get; set; }
    }
}
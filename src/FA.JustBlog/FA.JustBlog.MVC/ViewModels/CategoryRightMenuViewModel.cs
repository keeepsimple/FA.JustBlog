using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.MVC.ViewModels
{
    public class CategoryRightMenuViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int PostsCount { get; set; }
    }
}
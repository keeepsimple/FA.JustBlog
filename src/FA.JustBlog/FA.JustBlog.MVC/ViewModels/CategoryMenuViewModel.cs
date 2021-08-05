using FA.JustBlog.Models.Common;
using System.Collections.Generic;

namespace FA.JustBlog.MVC.ViewModels
{
    public class CategoryMenuViewModel
    {
        public IEnumerable<Category> PopularCategories { get; set; }
        public IEnumerable<Category> RemainCategories { get; set; }
    }
}
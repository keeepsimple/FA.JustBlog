using FA.JustBlog.Models.Common;
using System.Collections.Generic;

namespace FA.JustBlog.MVC.ViewModels
{
    public class CategoryMenuViewModel
    {
        public virtual IEnumerable<Category> PopularCategories { get; set; }
        public virtual IEnumerable<Category> RemainCategories { get; set; }
    }
}